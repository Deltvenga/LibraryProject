﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace LibraryService
{
    [DataContract]
    public class BookRepository
    {
        // [the elyaa string] string connectionString = "Data Source=LAPTOP-20V122MK;Integrated Security=SSPI;Initial Catalog=Library";
        string connectionString = "Data Source=DESKTOP-E4AU3DO;Initial Catalog=Library;Integrated Security=SSPI";

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

            return book;
        }

        [OperationContract]
        public Book[] FindBooks(string name)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From Books Where NameBook = '" + name + "';";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            

            List<Book> list = new List<Book>();
            DataTableReader dtreader = dt.CreateDataReader();
            int count;
            int idBook;
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

                SqlCommand countCmd = con.CreateCommand();
                countCmd.CommandType = CommandType.Text;
                countCmd.CommandText = "Select count(Abonement.id) From Abonement inner join Books on Books.idBook = Abonement.idBook and Books.NameBook = '" + name + "' where Abonement.idBook = '" + books.IdBook +"';";
                count = int.Parse(countCmd.ExecuteScalar().ToString());

                books.Captures = count;
                list.Add(books);
                count = 0;
            }

            con.Close();
            return list.ToArray();
        }
    }
}