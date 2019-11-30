using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace LibraryService
{
    [DataContract]
    public class Readers
    {
        [DataMember]
        List<Reader> _listReaders = new List<Reader>();

        //условно
        [OperationContract]
        public List<Reader> HasExpires(string date)
        {
            return _listReaders;
        }
    }
}