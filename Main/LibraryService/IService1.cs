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
        string AddNewReader(string[] array);

        [OperationContract]
        Tuple<List<string>, List<List<string>>> HasExpires();

        [OperationContract]
        Book[] GetBooks(string name, bool isOnlyAccessible);

        [OperationContract]
        string AddNewAbonement(int idReader, int idBook);

        [OperationContract]
        List<Reader> GetAllReaders();

        [OperationContract]
        Book[] GetWriteOffBooks();

        [OperationContract]
        List<Book> GetReplenishBooks();

        [OperationContract]
        void DeleteWriteOffBooks(int[] arr, string[] name);

        [OperationContract]
        void AddNewBook(Book newBook);

        [OperationContract]
        List<List<string>> GetAbonement(int id);

        [OperationContract]
        void ReturnBooks(int[] id, int[] idBook, string[] genre, int[] disrepair);

        [OperationContract]
        List<string> GetGenre();
    }
}
