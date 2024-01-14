using Maquisistema.Domain.Repository;
using Maquisistema.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Maquisistema.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MaquisistemaDbContext _maquisistemaDbContext;
        public GenericRepository(MaquisistemaDbContext maquisistemaDbContext)
        {
            _maquisistemaDbContext = maquisistemaDbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _maquisistemaDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _maquisistemaDbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            _maquisistemaDbContext.Set<T>().Add(entity);
            await _maquisistemaDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _maquisistemaDbContext.Entry(entity).State = EntityState.Modified;
            await _maquisistemaDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
