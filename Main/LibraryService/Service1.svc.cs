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

        string connectionString = "Data Source=LAPTOP-20V122MK;Integrated Security=SSPI;Initial Catalog=Library";

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

        public static Book[] writeOffBooks;

        public Book[] GetWriteOffBooks()
        {
            BookRepository bookRepository = new BookRepository();
            var books = bookRepository.GetWriteOffBooks();
            writeOffBooks = books;

            return books;
        }

        public Book[] GetReplenishBooks()
        {
            BookRepository bookRepository = new BookRepository();
            var books = bookRepository.ReplenishBooks();

            return books;
        }

        public void DeleteWriteOffBooks()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            for (int i = 0; i < writeOffBooks.Length; i++)
            {
                if (writeOffBooks[i].Status != "Выдана")
                {
                    cmd.CommandText = "Delete From Books Where idBook = '" + writeOffBooks[i].IdBook + "';";
                    cmd.ExecuteNonQuery();
                }
                    
            }
            
            con.Close();
        }
    }
}
