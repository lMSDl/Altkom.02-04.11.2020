using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICrudService<T> where T : class, new()
    {
        T Create(T entity);
        T Read(int id);
        ICollection<T> Read();
        void Update(T entity);
        bool Delete(int id);
    }
}
