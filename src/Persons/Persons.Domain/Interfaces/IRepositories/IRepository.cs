using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        Task AddAsync(TEntity obj);
        TEntity GetById(long id);
        Task<TEntity> GetByIdAsync(long id);
        IQueryable<TEntity> GetAll();
        Task<IQueryable<TEntity>> GetAllAsync();
        void Update(TEntity obj);
        Task UpdateAsync(TEntity obj);
        void Remove(long id);
        int SaveChanges();
    }
}
