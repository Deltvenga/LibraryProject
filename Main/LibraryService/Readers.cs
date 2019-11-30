using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data;
using System.Data.SqlClient;

namespace LibraryService
{
    [DataContract]
    public class Readers
    {
        [DataMember]
        List<Reader> _listReaders = new List<Reader>();

        string connectionString = "Data Source=LAPTOP-20V122MK;Integrated Security=SSPI;Initial Catalog=Library";
        
        [OperationContract]
        public List<Reader> HasExpires(string date)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select DataFactEnd From Abonement Where DataEnd ";
            return _listReaders;
        }

        private string getDate(int day, int month, int year)
        {
            return (year + '-' + month + '-' + day).ToString();
        }
    }
}