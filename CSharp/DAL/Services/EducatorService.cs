using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class EducatorsService : CrudServiceAsync<Educator>, IEducatorsService
    {
        public async Task<ICollection<Educator>> ReadBySpecializationAsync(string specialization)
        {
            using (var context = new Context())
            {
                return await context.Set<Educator>().Where(x => x.Specialization == specialization).ToListAsync();
            }
        }

        public async Task<ICollection<Educator>> Read(int limit)
        {
            using (var context = new Context())
            {
                return await context.Set<Educator>().Take(limit).ToListAsync();
            }
        }
    }
}
