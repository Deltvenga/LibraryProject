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
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/LibraryService")]
    [System.SerializableAttribute()]
    internal partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Book", Namespace="http://schemas.datacontract.org/2004/07/LibraryService")]
    [System.SerializableAttribute()]
    internal partial class Book : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CapturesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DisrepairField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdBookField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LanguageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameBookField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PageCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PublishField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PublishCountryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int YearField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal int Captures {
            get {
                return this.CapturesField;
            }
            set {
                if ((this.CapturesField.Equals(value) != true)) {
                    this.CapturesField = value;
                    this.RaisePropertyChanged("Captures");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal int Disrepair {
            get {
                return this.DisrepairField;
            }
            set {
                if ((this.DisrepairField.Equals(value) != true)) {
                    this.DisrepairField = value;
                    this.RaisePropertyChanged("Disrepair");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal int IdBook {
            get {
                return this.IdBookField;
            }
            set {
                if ((this.IdBookField.Equals(value) != true)) {
                    this.IdBookField = value;
                    this.RaisePropertyChanged("IdBook");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string Language {
            get {
                return this.LanguageField;
            }
            set {
                if ((object.ReferenceEquals(this.LanguageField, value) != true)) {
                    this.LanguageField = value;
                    this.RaisePropertyChanged("Language");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string NameBook {
            get {
                return this.NameBookField;
            }
            set {
                if ((object.ReferenceEquals(this.NameBookField, value) != true)) {
                    this.NameBookField = value;
                    this.RaisePropertyChanged("NameBook");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal int PageCount {
            get {
                return this.PageCountField;
            }
            set {
                if ((this.PageCountField.Equals(value) != true)) {
                    this.PageCountField = value;
                    this.RaisePropertyChanged("PageCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string Publish {
            get {
                return this.PublishField;
            }
            set {
                if ((object.ReferenceEquals(this.PublishField, value) != true)) {
                    this.PublishField = value;
                    this.RaisePropertyChanged("Publish");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string PublishCountry {
            get {
                return this.PublishCountryField;
            }
            set {
                if ((object.ReferenceEquals(this.PublishCountryField, value) != true)) {
                    this.PublishCountryField = value;
                    this.RaisePropertyChanged("PublishCountry");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal int Year {
            get {
                return this.YearField;
            }
            set {
                if ((this.YearField.Equals(value) != true)) {
                    this.YearField = value;
                    this.RaisePropertyChanged("Year");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    internal interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        Main.ServiceReference1.CompositeType GetDataUsingDataContract(Main.ServiceReference1.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<Main.ServiceReference1.CompositeType> GetDataUsingDataContractAsync(Main.ServiceReference1.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewReader", ReplyAction="http://tempuri.org/IService1/AddNewReaderResponse")]
        void AddNewReader(string[] array);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewReader", ReplyAction="http://tempuri.org/IService1/AddNewReaderResponse")]
        System.Threading.Tasks.Task AddNewReaderAsync(string[] array);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/HasExpires", ReplyAction="http://tempuri.org/IService1/HasExpiresResponse")]
        System.Tuple<string[], string[][]> HasExpires();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/HasExpires", ReplyAction="http://tempuri.org/IService1/HasExpiresResponse")]
        System.Threading.Tasks.Task<System.Tuple<string[], string[][]>> HasExpiresAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetBooks", ReplyAction="http://tempuri.org/IService1/GetBooksResponse")]
        Main.ServiceReference1.Book[] GetBooks(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetBooks", ReplyAction="http://tempuri.org/IService1/GetBooksResponse")]
        System.Threading.Tasks.Task<Main.ServiceReference1.Book[]> GetBooksAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewAbonement", ReplyAction="http://tempuri.org/IService1/AddNewAbonementResponse")]
        string AddNewAbonement(int idReader, int idBook);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddNewAbonement", ReplyAction="http://tempuri.org/IService1/AddNewAbonementResponse")]
        System.Threading.Tasks.Task<string> AddNewAbonementAsync(int idReader, int idBook);
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
        
        public Main.ServiceReference1.CompositeType GetDataUsingDataContract(Main.ServiceReference1.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<Main.ServiceReference1.CompositeType> GetDataUsingDataContractAsync(Main.ServiceReference1.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
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
        
        public Main.ServiceReference1.Book[] GetBooks(string name) {
            return base.Channel.GetBooks(name);
        }
        
        public System.Threading.Tasks.Task<Main.ServiceReference1.Book[]> GetBooksAsync(string name) {
            return base.Channel.GetBooksAsync(name);
        }
        
        public string AddNewAbonement(int idReader, int idBook) {
            return base.Channel.AddNewAbonement(idReader, idBook);
        }
        
        public System.Threading.Tasks.Task<string> AddNewAbonementAsync(int idReader, int idBook) {
            return base.Channel.AddNewAbonementAsync(idReader, idBook);
        }
    }
}