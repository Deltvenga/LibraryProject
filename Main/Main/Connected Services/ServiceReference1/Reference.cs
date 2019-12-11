﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Main.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    internal interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewReader", ReplyAction="http://tempuri.org/IService1/AddNewReaderResponse")]
        void AddNewReader(string[] array);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewReader", ReplyAction="http://tempuri.org/IService1/AddNewReaderResponse")]
        System.Threading.Tasks.Task AddNewReaderAsync(string[] array);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/HasExpires", ReplyAction="http://tempuri.org/IService1/HasExpiresResponse")]
        System.Tuple<string[], string[][]> HasExpires();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/HasExpires", ReplyAction="http://tempuri.org/IService1/HasExpiresResponse")]
        System.Threading.Tasks.Task<System.Tuple<string[], string[][]>> HasExpiresAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetBooks", ReplyAction="http://tempuri.org/IService1/GetBooksResponse")]
        LibraryService.Book[] GetBooks(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetBooks", ReplyAction="http://tempuri.org/IService1/GetBooksResponse")]
        System.Threading.Tasks.Task<LibraryService.Book[]> GetBooksAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewAbonement", ReplyAction="http://tempuri.org/IService1/AddNewAbonementResponse")]
        string AddNewAbonement(int idReader, int idBook);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewAbonement", ReplyAction="http://tempuri.org/IService1/AddNewAbonementResponse")]
        System.Threading.Tasks.Task<string> AddNewAbonementAsync(int idReader, int idBook);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllReaders", ReplyAction="http://tempuri.org/IService1/GetAllReadersResponse")]
        LibraryService.Reader[] GetAllReaders();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllReaders", ReplyAction="http://tempuri.org/IService1/GetAllReadersResponse")]
        System.Threading.Tasks.Task<LibraryService.Reader[]> GetAllReadersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetWriteOffBooks", ReplyAction="http://tempuri.org/IService1/GetWriteOffBooksResponse")]
        LibraryService.Book[] GetWriteOffBooks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetWriteOffBooks", ReplyAction="http://tempuri.org/IService1/GetWriteOffBooksResponse")]
        System.Threading.Tasks.Task<LibraryService.Book[]> GetWriteOffBooksAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetReplenishBooks", ReplyAction="http://tempuri.org/IService1/GetReplenishBooksResponse")]
        LibraryService.Book[] GetReplenishBooks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetReplenishBooks", ReplyAction="http://tempuri.org/IService1/GetReplenishBooksResponse")]
        System.Threading.Tasks.Task<LibraryService.Book[]> GetReplenishBooksAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteWriteOffBooks", ReplyAction="http://tempuri.org/IService1/DeleteWriteOffBooksResponse")]
        void DeleteWriteOffBooks(int[] arr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteWriteOffBooks", ReplyAction="http://tempuri.org/IService1/DeleteWriteOffBooksResponse")]
        System.Threading.Tasks.Task DeleteWriteOffBooksAsync(int[] arr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewBook", ReplyAction="http://tempuri.org/IService1/AddNewBookResponse")]
        void AddNewBook(LibraryService.Book newBook);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewBook", ReplyAction="http://tempuri.org/IService1/AddNewBookResponse")]
        System.Threading.Tasks.Task AddNewBookAsync(LibraryService.Book newBook);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal interface IService1Channel : Main.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal partial class Service1Client : System.ServiceModel.ClientBase<Main.ServiceReference1.IService1>, Main.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public void AddNewReader(string[] array) {
            base.Channel.AddNewReader(array);
        }
        
        public System.Threading.Tasks.Task AddNewReaderAsync(string[] array) {
            return base.Channel.AddNewReaderAsync(array);
        }
        
        public System.Tuple<string[], string[][]> HasExpires() {
            return base.Channel.HasExpires();
        }
        
        public System.Threading.Tasks.Task<System.Tuple<string[], string[][]>> HasExpiresAsync() {
            return base.Channel.HasExpiresAsync();
        }
        
        public LibraryService.Book[] GetBooks(string name) {
            return base.Channel.GetBooks(name);
        }
        
        public System.Threading.Tasks.Task<LibraryService.Book[]> GetBooksAsync(string name) {
            return base.Channel.GetBooksAsync(name);
        }
        
        public string AddNewAbonement(int idReader, int idBook) {
            return base.Channel.AddNewAbonement(idReader, idBook);
        }
        
        public System.Threading.Tasks.Task<string> AddNewAbonementAsync(int idReader, int idBook) {
            return base.Channel.AddNewAbonementAsync(idReader, idBook);
        }
        
        public LibraryService.Reader[] GetAllReaders() {
            return base.Channel.GetAllReaders();
        }
        
        public System.Threading.Tasks.Task<LibraryService.Reader[]> GetAllReadersAsync() {
            return base.Channel.GetAllReadersAsync();
        }
        
        public LibraryService.Book[] GetWriteOffBooks() {
            return base.Channel.GetWriteOffBooks();
        }
        
        public System.Threading.Tasks.Task<LibraryService.Book[]> GetWriteOffBooksAsync() {
            return base.Channel.GetWriteOffBooksAsync();
        }
        
        public LibraryService.Book[] GetReplenishBooks() {
            return base.Channel.GetReplenishBooks();
        }
        
        public System.Threading.Tasks.Task<LibraryService.Book[]> GetReplenishBooksAsync() {
            return base.Channel.GetReplenishBooksAsync();
        }
        
        public void DeleteWriteOffBooks(int[] arr) {
            base.Channel.DeleteWriteOffBooks(arr);
        }
        
        public System.Threading.Tasks.Task DeleteWriteOffBooksAsync(int[] arr) {
            return base.Channel.DeleteWriteOffBooksAsync(arr);
        }
        
        public void AddNewBook(LibraryService.Book newBook) {
            base.Channel.AddNewBook(newBook);
        }
        
        public System.Threading.Tasks.Task AddNewBookAsync(LibraryService.Book newBook) {
            return base.Channel.AddNewBookAsync(newBook);
        }
    }
}
