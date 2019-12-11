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

        public static List<string> writedOffBooks = new List<string>();

        public Book[] GetWriteOffBooks()
        {
            BookRepository bookRepository = new BookRepository();
            var books = bookRepository.GetWriteOffBooks();
            //writeOffBooks = books;

            return books;
        }

        public List<Book> GetReplenishBooks()
        {
            BookRepository bookRepository = new BookRepository();
            var books = bookRepository.ReplenishBooks();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            for (int i = 0; i < writedOffBooks.Count; i++)
            {
                cmd.CommandText = "Select NameBook From Books Where NameBook = '" + writedOffBooks[i] + "';";

                if ((string)cmd.ExecuteScalar() == null)
                {
                    Book newBook = new Book();
                    newBook.NameBook = writedOffBooks[i];
                    newBook.CountPhonetic = 0;
                    books.Add(newBook);
                }                                     
            }                             
            
            return books;
        }

        public void DeleteWriteOffBooks(int[] writeOffBooks)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            SqlCommand newCom = con.CreateCommand();
            newCom.CommandType = CommandType.Text;
            //newCom.CommandText = "Select"
            for (int i = 0; i < writeOffBooks.Length; i++)
            {
                newCom.CommandText = "Select NameBook From Books Where idBook = '" + writeOffBooks[i] + "';";
                
                writedOffBooks.Add((string)newCom.ExecuteScalar());
                //cmd.CommandText = "Update Books Set Status = 'Списана' Where idBook = '" + writeOffBooks[i] + "';";
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

        
        
    }
}
