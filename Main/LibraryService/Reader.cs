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
        [DataMember]
        public int IdReader { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public string BirthDate { get; set; }

        [DataMember]
        public int PassportSerial { get; set; }

        [DataMember]
        public int PassportNumber { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }
    }
}