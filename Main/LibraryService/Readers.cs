using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data;
using System.Data.SqlClient;
using System.Timers;

namespace LibraryService
{
    [DataContract]
    public class Readers
    {
        string connectionString = "Data Source=LAPTOP-20V122MK;Integrated Security=SSPI;Initial Catalog=Library";

        public Readers()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * FROM Readers";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataTableReader DTReader = dt.CreateDataReader();
            while (DTReader.Read())
            {
                _listReaders.Add(readerFormer(DTReader));
            }
        }

        private Reader readerFormer(DataTableReader DTReader)
        {
            Reader reader = new Reader();
            reader.IdReader = int.Parse(DTReader["idReader"].ToString());
            reader.FirstName = DTReader["firstName"].ToString();
            reader.LastName = DTReader["lastName"].ToString();
            reader.MiddleName = DTReader["middleName"].ToString();
            reader.BirthDate = DTReader["birthDate"].ToString();
            reader.PassportSerial = int.Parse(DTReader["passportSerial"].ToString()); ;
            reader.PassportNumber = int.Parse(DTReader["passportNumber"].ToString()); ;
            reader.Address = DTReader["Address"].ToString();
            reader.PhoneNumber = DTReader["PhoneNumber"].ToString();
            return reader;
        }

        [DataMember]
        List<Reader> _listReaders = new List<Reader>();

        [OperationContract]
        public Tuple<List<string>, List<List<string>>> HasExpires()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Readers.firstName, Readers.lastName, Readers.middleName, Readers.phoneNumber, Books.NameBook From Abonement inner join Readers on Abonement.idReader = Readers.idReader inner join Books on Books.idBook = Abonement.idBook where Abonement.DataEnd < '" + getDateNow() + "' and DataFactEnd is null;";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            //var test = new DataTable();
            //test.Columns.Add("firstName");
            //test.Columns.Add("lastName");
            //test.Columns.Add("middleName");
            //test.Columns.Add("phoneNumber");
            //test.Columns.Add("NameBook");
            var test2 = new Dictionary<string, List<string>>()
            {
                ["firstName"] = new List<string>(),
                ["lastName"] = new List<string>(),
                ["middleName"] = new List<string>(),
                ["phoneNumber"] = new List<string>(),
                ["NameBook"] = new List<string>()
            };
            var columns = new List<string>()
            {
                "firstName",
                "lastName",
                "middleName",
                "phoneNumber",
                "NameBook"
            };
            var rows = new List<List<string>>();
            DataTableReader reader = dt.CreateDataReader();

            while (reader.Read())
            {              
                test2["firstName"].Add(reader["firstName"].ToString());
                test2["lastName"].Add(reader["lastName"].ToString());
                test2["middleName"].Add(reader["middleName"].ToString());
                test2["phoneNumber"].Add(reader["phoneNumber"].ToString());
                test2["NameBook"].Add(reader["NameBook"].ToString());
                rows.Add(new List<string> {
                    reader["firstName"].ToString(),
                    reader["lastName"].ToString(),
                    reader["middleName"].ToString(),
                    reader["phoneNumber"].ToString(),
                    reader["NameBook"].ToString()
                });
                //test.Rows.Add(reader["firstName"].ToString(), reader["lastName"].ToString(), reader["middleName"].ToString(), reader["phoneNumber"].ToString(), reader["NameBook"].ToString());
            }
            return Tuple.Create(columns, rows);
        }

        private string getDate(int day, int month, int year)
        {
            //$"{year}-{month}-{day}";
            var g = (year + '-' + month + '-' + day).ToString();
            return (year + '-' + month + '-' + day).ToString();
        }

        private string getDateNow()
        {
            var day = DateTime.Now.Day;
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            return year + "-" + month + "-" + day;
            //return getDate(day, month, year);
        }
    }
}