using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.ServiceModel;
using LibraryService.Properties;

namespace LibraryService
{
    [DataContract]
    public class BookRepository
    {
        static string connectionString = Settings.Default.ElyaCon;

        [DataMember]
        List<Book> _listBooks = new List<Book>();

        public BookRepository()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * FROM Books";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataTableReader DTReader = dt.CreateDataReader();

            while (DTReader.Read())
            {
                _listBooks.Add(bookFormer(DTReader));
            }
        }

        private Book bookFormer(DataTableReader DTReader)
        {
            Book book = new Book();

            book.IdBook = int.Parse(DTReader["idBook"].ToString());
            book.NameBook = DTReader["NameBook"].ToString();
            book.Year = int.Parse(DTReader["Year"].ToString());
            book.Publish = DTReader["Publish"].ToString();
            book.PublishCountry = DTReader["PublishCountry"].ToString();
            book.PageCount = int.Parse(DTReader["PageCount"].ToString());
            book.Language = DTReader["Language"].ToString();
            book.Captures = int.Parse(DTReader["Captures"].ToString());
            book.Disrepair = int.Parse(DTReader["Disrepair"].ToString());
            book.Status = DTReader["Status"].ToString();

            return book;
        }

        [OperationContract]
        public Book[] FindBooks(string searchString, bool isOnlyAccessible)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string sqlString = "Select * From Books Where (lower(NameBook) LIKE lower('%?%') OR idBook LIKE ('?') OR lower(Publish) LIKE lower('%?%'))";
            if (isOnlyAccessible) sqlString += "AND Status <> 'Выдана'";
            cmd.CommandText = sqlString.Replace("?", searchString);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            

            List<Book> list = new List<Book>();
            DataTableReader dtreader = dt.CreateDataReader();
            int count;
            
            while (dtreader.Read())
            {
                Book books = new Book();
                books.IdBook = int.Parse(dtreader["IdBook"].ToString());
                books.NameBook = dtreader["NameBook"].ToString();
                books.Year = int.Parse(dtreader["Year"].ToString());
                books.Publish = dtreader["Publish"].ToString();
                books.PublishCountry = dtreader["PublishCountry"].ToString();
                books.PageCount = int.Parse(dtreader["PageCount"].ToString());
                books.Language = dtreader["Language"].ToString();                
                books.Disrepair = int.Parse(dtreader["Disrepair"].ToString());
                books.Status = dtreader["Status"].ToString();

                SqlCommand countCmd = con.CreateCommand();
                countCmd.CommandType = CommandType.Text;
                countCmd.CommandText = "Select count(Abonement.id) From Abonement inner join Books on Books.idBook = Abonement.idBook where Abonement.idBook = '" + books.IdBook +"';";
                count = int.Parse(countCmd.ExecuteScalar().ToString());

                books.Captures = count;
                list.Add(books);
                count = 0;
            }

            con.Close();
            return list.ToArray();
        }

        [OperationContract]
        public Book[] GetWriteOffBooks()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From Books Where Disrepair = 1 and Status <> 'Выдана';";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Book> list = new List<Book>();
            DataTableReader dtreader = dt.CreateDataReader();

            while (dtreader.Read())
            {
                Book books = new Book();
                books = bookFormer(dtreader);
                list.Add(books);
            }

            return list.ToArray();
        }

        const int MIN_BOOKS_COUNT = 3; // минимальное количество книг

        [OperationContract]
        public List<Book> ReplenishBooks()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand precmd = con.CreateCommand();
            precmd.CommandType = CommandType.Text;
            precmd.CommandText = "Truncate Table ReplenishBooks;";
            precmd.ExecuteNonQuery();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select NameBook, Count(NameBook) as Kol From Books Where NameBook = NameBook Group By NameBook;";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Book> list = new List<Book>();
            DataTableReader dtreader = dt.CreateDataReader();

            while (dtreader.Read())
            {
                Book books = new Book();
                books.NameBook = dtreader["NameBook"].ToString();
                books.CountPhonetic = int.Parse(dtreader["Kol"].ToString());

                if (books.CountPhonetic < MIN_BOOKS_COUNT)
                {                  
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Insert into ReplenishBooks Values('" + books.NameBook + "', '" + books.CountPhonetic + "');";
                    command.ExecuteNonQuery();                 
                }              
            }

            SqlCommand writedBooks = con.CreateCommand();
            writedBooks.CommandType = CommandType.Text;
            writedBooks.CommandText = "Select NameBook From WritedOffBooks";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(writedBooks);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            DataTableReader dataTableReader = dataTable.CreateDataReader();

            while (dataTableReader.Read())
            {
                Book nbooks = new Book();
                nbooks.NameBook = dataTableReader["NameBook"].ToString();

                SqlCommand check = con.CreateCommand();
                check.CommandType = CommandType.Text;
                check.CommandText = "Select Count(NameBook) From ReplenishBooks Where NameBook = '" + nbooks.NameBook + "';";
                if ((int)check.ExecuteScalar() == 0)
                {
                    SqlCommand insert = con.CreateCommand();
                    insert.CommandType = CommandType.Text;
                    insert.CommandText = "Insert into ReplenishBooks Values ('" + nbooks.NameBook + "', 0);";
                    insert.ExecuteNonQuery();
                }
            }

            SqlCommand cmdReplenish = con.CreateCommand();
            cmdReplenish.CommandType = CommandType.Text;
            cmdReplenish.CommandText = "Select * From ReplenishBooks";

            SqlDataAdapter sda = new SqlDataAdapter(cmdReplenish);
            DataTable datat = new DataTable();
            sda.Fill(datat);

            List<Book> replenishList = new List<Book>();
            DataTableReader DTreader = datat.CreateDataReader();

            while (DTreader.Read())
            {
                Book books = new Book();
                books.NameBook = DTreader["NameBook"].ToString();
                books.CountPhonetic = (MIN_BOOKS_COUNT + 1 - int.Parse(DTreader["CountBooks"].ToString()));
                replenishList.Add(books);             
            }

            con.Close();
            return replenishList;
        }

        public void AddNewBook(Book newBook)
        {
            string query = "Insert into [Books] values('" + newBook.NameBook + "'," + newBook.Year + "," +
                "'" + newBook.Publish + "'," +
                "'" + newBook.PublishCountry + "'," + newBook.PageCount + "," +
                "'" + newBook.Language + "',0," + newBook.Disrepair + ",null)";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            
        }
    }
}