using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace LibraryService
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int IdBook { get; set; }

        [DataMember]
        public string NameBook { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public string Publish { get; set; }

        [DataMember]
        public string PublishCountry { get; set; }

        [DataMember]
        public int PageCount { get; set; }

        [DataMember]
        public string Language { get; set; }

        //Надо норм название придумать "Кол-во раз взяли"
        [DataMember]
        public int Captures { get; set; }

        [DataMember]
        public int Disrepair { get; set; }
    }
}