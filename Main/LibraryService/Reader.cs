using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace LibraryService
{
    [DataContract]
    public class Reader
    {
        int _idReader;
        string _firstName;
        string _lastName;
        string _middleName;
        string _birthDate;
        int _passportSerial;
        int _passportNumber;
        string _address;
        string _phoneNumber;

        [DataMember]
        public int IdReader
        {
            get { return _idReader; }
            set { _idReader = value; }
        }

        [DataMember]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        [DataMember]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        [DataMember]
        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }

        [DataMember]
        public string BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        [DataMember]
        public int PassportSerial
        {
            get { return _passportSerial; }
            set { _passportSerial = value; }
        }

        [DataMember]
        public int PassportNumber
        {
            get { return _passportNumber; }
            set { _passportNumber = value; }
        }

        [DataMember]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        [DataMember]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
    }
}