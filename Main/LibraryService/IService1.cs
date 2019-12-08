using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LibraryService
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        void AddNewReader(string[] array);

        [OperationContract]
        Tuple<List<string>, List<List<string>>> HasExpires();

        [OperationContract]
        Book[] GetBooks(string name);

        [OperationContract]
        string AddNewAbonement(int idReader, int idBook);

        [OperationContract]
        List<Reader> GetAllReaders();
    }
}
