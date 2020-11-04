using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DAL.Services;
using Models;

namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DALService" in both code and config file together.
    public class DALService : IDALService
    {


        public async Task<ICollection<Educator>> ReadAsync()
        {
            return await new EducatorsService().ReadAsync();
        }
    }
}
