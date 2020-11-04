using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDALService" in both code and config file together.
    [ServiceContract]
    public interface IDALService 
    {
        [OperationContract]
        Task<ICollection<Educator>> ReadAsync();
    }
}
