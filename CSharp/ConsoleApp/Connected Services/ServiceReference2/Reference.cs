﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IDALService")]
    public interface IDALService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDALService/Read", ReplyAction="http://tempuri.org/IDALService/ReadResponse")]
        Models.Educator[] Read();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDALService/Read", ReplyAction="http://tempuri.org/IDALService/ReadResponse")]
        System.Threading.Tasks.Task<Models.Educator[]> ReadAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDALServiceChannel : ConsoleApp.ServiceReference2.IDALService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DALServiceClient : System.ServiceModel.ClientBase<ConsoleApp.ServiceReference2.IDALService>, ConsoleApp.ServiceReference2.IDALService {
        
        public DALServiceClient() {
        }
        
        public DALServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DALServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DALServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DALServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Models.Educator[] Read() {
            return base.Channel.Read();
        }
        
        public System.Threading.Tasks.Task<Models.Educator[]> ReadAsync() {
            return base.Channel.ReadAsync();
        }
    }
}