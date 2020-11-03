using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEducatorsService : ICrudServiceAsync<Educator>
    {
        Task<ICollection<Educator>> ReadBySpecializationAsync(string specialization);
    }
}
