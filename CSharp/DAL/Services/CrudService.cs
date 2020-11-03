using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class CrudService<T> : ICrudService<T> where T : class, new()
    {
        public T Create(T entity)
        {
            using (var context = new Context())
            {

                entity = context.Set<T>().Add(entity);
                context.SaveChanges();
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

        public bool Delete(int id)
        {
            var entity = Read(id);
            if (entity == null)
                return false;
            using (var context = new Context())
            {
                context.Set<T>().Attach(entity);
                context.Set<T>().Remove(entity);
                context.SaveChanges();
                return true;
            }
        }

        public T Read(int id)
        {
            using (var context = new Context())
            {
                return context.Set<T>().Find(id);
            }
        }

        public ICollection<T> Read()
        {
            using (var context = new Context())
            {
                //return context.Database.SqlQuery<T>("SELECT * FROM dbo.Educators").ToList();
                return context.Set<T>().ToList();
            }
        }

        public void Update(T entity)
        {
            using (var context = new Context())
            {
                context.Set<T>().Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
