using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class CrudServiceAsync<T> : ICrudServiceAsync<T> where T : class, new()
    {
        public async Task<T> CreateAsync(T entity)
        {
            using (var context = new Context())
            {
                entity = context.Set<T>().Add(entity);
                await context.SaveChangesAsync();
            }
            return entity;
        }

        //public bool Delete(int id)
        //{
        //    using (var context = new Context())
        //    {
        //        var entity = context.Set<T>().Find(id);
        //        if (entity == null)
        //            return false;
        //        context.Set<T>().Remove(entity);
        //        context.SaveChanges();
        //        return true;
        //    }
        //}

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await ReadAsync(id);
            if (entity == null)
                return false;
            using (var context = new Context())
            {
                context.Set<T>().Attach(entity);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<T> ReadAsync(int id)
        {
            using (var context = new Context())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }

        public async Task<ICollection<T>> ReadAsync()
        {
            using (var context = new Context())
            {
                //await Task.Delay(5000);
                //return context.Database.SqlQuery<T>("SELECT * FROM dbo.Educators").ToList();
                return await context.Set<T>().ToListAsync();
            }
        }


        public async Task UpdateAsync(T entity)
        {
            using (var context = new Context())
            {
                context.Set<T>().Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
