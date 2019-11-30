﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LibraryService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        string connectionString = "Data Source=LAPTOP-20V122MK;Integrated Security=SSPI;Initial Catalog=Library";

        public void AddNewReader(string[] newReaderArray)
        {
            //проверки на пустые поля, серия - 4 цифры (первая - не ноль), номер - 6 цифр (аналогично), номер телефона - 11 цифр
            //фио - из букв, телефон, паспорт - из цифр
            //CheckError(newReaderArray);

            if (!CheckBlackList(newReaderArray[4], newReaderArray[5]))
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText =
                    "Insert into [Readers] values('" + newReaderArray[0] + "', '" + newReaderArray[1] + "', '" + newReaderArray[2] + "', '" + newReaderArray[3] + "', '" + int.Parse(newReaderArray[4]) + "', '" + int.Parse(newReaderArray[5]) + "', '" + newReaderArray[6] + "', '" + newReaderArray[7] + "');";
                cmd.ExecuteNonQuery();

                con.Close();
            }           
        }

        //public string CheckError(string[] array)
        //{
        //    string str = "";
        //    return str;
        //}

        public bool CheckBlackList(string passportSerial, string passportNumber)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                "Select idReader From BlackList, Readers Where Readers.passportSerial = '" + passportSerial + "' and Readers.passportNumber = '" + passportNumber + "';";
            string result = cmd.ExecuteScalar().ToString();

            if (result != null)
                return true;
            return false;
        }
    }
}