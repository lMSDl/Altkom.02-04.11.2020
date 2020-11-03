using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICrudServiceAsync<T> where T : class, new()
    {
        Task<T> CreateAsync(T entity);
        Task<T> ReadAsync(int id);
        Task<ICollection<T>> ReadAsync();
        Task UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
