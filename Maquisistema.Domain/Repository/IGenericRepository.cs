using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Maquisistema.Domain.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
