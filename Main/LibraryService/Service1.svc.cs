using LibraryService.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LibraryService
{   
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        static string connectionString = Settings.Default.ElyaCon;

        public void AddNewReader(string[] newReaderArray)
        {
            //if (!CheckBlackList(newReaderArray[4], newReaderArray[5]))
            //{
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "Insert into [Readers] values('" + newReaderArray[0] + "', '" + newReaderArray[1] + "', '" + newReaderArray[2] + "', '" + newReaderArray[3] + "', '" + int.Parse(newReaderArray[4]) + "', '" + int.Parse(newReaderArray[5]) + "', '" + newReaderArray[6] + "', '" + newReaderArray[7] + "');";
                cmd.ExecuteNonQuery();

                con.Close();
            //}           
        }

        //public bool CheckBlackList(string passportSerial, string passportNumber)
        //{
        //    SqlConnection con = new SqlConnection(connectionString);
        //    con.Open();
        //    SqlCommand cmd = con.CreateCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText =
        //        "Select idReader From BlackList, Readers Where Readers.passportSerial = '" + passportSerial + "' and Readers.passportNumber = '" + passportNumber + "';";
        //    string result = cmd.ExecuteScalar().ToString();

        //    if (result != null)
        //        return true;
        //    return false;
        //}

        public Tuple<List<string>, List<List<string>>> HasExpires()
        {
            Readers readers = new Readers();
            var hh = readers.HasExpires();

            return hh;
        }

        public Book[] GetBooks(string name)
        {
            BookRepository bookRepository = new BookRepository();
            var books = bookRepository.FindBooks(name);
            return books;
        }

        public string AddNewAbonement(int idReader, int idBook)
        {
            var day = DateTime.Now.Day;
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;

            var dateNow = (year + "-" + month + "-" + day).ToString();
            var dateEnd = DateTime.Now.Date.AddDays(10).ToShortDateString();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into Abonement Values('" + idReader + "','" + idBook + "','" + dateNow + "','" + dateEnd + "', NULL);";
            cmd.ExecuteNonQuery();

            SqlCommand cmdBooks = con.CreateCommand();
            cmdBooks.CommandType = CommandType.Text;
            cmdBooks.CommandText = "Update Books Set Status = 'Выдана' Where idBook ='" + idBook +"';";
            cmdBooks.ExecuteNonQuery();
            return dateEnd.ToString();
        }

        public List<Reader> GetAllReaders()
        {
            List<Reader> readers = new List<Reader>();
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * From Readers";
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader dataReader = command.ExecuteReader();
            
            while (dataReader.Read())
            {
                Reader reader = new Reader();  
                reader.IdReader = int.Parse(dataReader[0].ToString());
                reader.FirstName = dataReader[1].ToString();
                reader.LastName = dataReader[2].ToString();
                reader.MiddleName = dataReader[3].ToString();
                reader.BirthDate = dataReader[4].ToString();
                reader.PassportSerial = int.Parse(dataReader[5].ToString());
                reader.PassportNumber = int.Parse(dataReader[6].ToString());
                reader.Address = dataReader[7].ToString();
                reader.PhoneNumber = dataReader[8].ToString();
                readers.Add(reader);
            }
            dataReader.Close();
            con.Close();
            return readers;

        }

        //public static List<string> writedOffBooks = new List<string>();

        public Book[] GetWriteOffBooks()
        {
            BookRepository bookRepository = new BookRepository();
            var books = bookRepository.GetWriteOffBooks();          
            return books;
        }

        public List<Book> GetReplenishBooks()
        {
            BookRepository bookRepository = new BookRepository();
            var books = bookRepository.ReplenishBooks();   
            return books;
        }

        public void DeleteWriteOffBooks(int[] writeOffBooks, string[] name)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
           
            for (int i = 0; i < writeOffBooks.Length; i++)
            {
                SqlCommand sqlCommand = con.CreateCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "Select Count(NameBook) From Books Where NameBook = '" + name[i] + "';";
                if ((int)sqlCommand.ExecuteScalar() < 3)
                {
                    SqlCommand command = con.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Insert into WritedOffBooks Values ('" + name[i] + "');";
                    command.ExecuteNonQuery();
                }

                cmd.CommandText = "Delete From Books Where idBook = '" + writeOffBooks[i] + "';";
                cmd.ExecuteNonQuery();                                              
            }      

            con.Close();
        }

        public void AddNewBook(Book newBook)
        {
            BookRepository bookRepository = new BookRepository();
            bookRepository.AddNewBook(newBook);
        }     

        public List<List<string>> GetAbonement(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Abonement.id, Books.idBook, Books.NameBook, Abonement.DataBegin, Abonement.DataEnd, Abonement.DataFactEnd From Abonement Inner join Readers on Abonement.idReader = Readers.idReader inner join Books on Abonement.idBook = Books.idBook Where Abonement.idReader = '" + id + "' and Abonement.DataFactEnd is null;";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<List<string>> list = new List<List<string>>();
            DataTableReader dtreader = dt.CreateDataReader();

            while (dtreader.Read())
            {
                List<string> rows = new List<string>();
                rows.Add(dtreader["id"].ToString());
                //rows.Add(dtreader["firstName"].ToString() + " " + dtreader["lastName"].ToString() + " " + dtreader["middleName"].ToString());
                rows.Add(dtreader["idBook"].ToString());
                rows.Add(dtreader["NameBook"].ToString());
                rows.Add(dtreader["DataBegin"].ToString());
                rows.Add(dtreader["DataEnd"].ToString());
                rows.Add(dtreader["DataFactEnd"].ToString());
                list.Add(rows);
            }

            con.Close();
            return list;
        }

        public void ReturnBooks(int[] id, int[] idBook, string[] genre)
        {
            var day = DateTime.Now.Day;
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;

            var dateNow = (year + "-" + month + "-" + day).ToString();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            for (int i = 0; i < id.Length; i++)
            {
                cmd.CommandText = "Update Abonement Set DataFactEnd = '" + dateNow + "' Where id = '" + id[i] + "';";
                cmd.ExecuteNonQuery();
                
                SqlCommand changeStatus = con.CreateCommand();
                changeStatus.CommandType = CommandType.Text;
                changeStatus.CommandText = "Update Books Set Status = '" + genre[i] + "' Where idBook = '" + idBook[i] + "';";
                changeStatus.ExecuteNonQuery();
            }
            con.Close();
        }

        public List<string> GetGenre()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Genre From [Genre]";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<string> list = new List<string>();
            DataTableReader dtreader = dt.CreateDataReader();
            while (dtreader.Read())
            {
                list.Add(dtreader["Genre"].ToString());
            }
            con.Close();
            return list;
        }
    }
}
