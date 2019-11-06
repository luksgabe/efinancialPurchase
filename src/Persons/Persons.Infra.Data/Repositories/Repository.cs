using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persons.Domain.Interfaces;
using Persons.Infra.Data.Context;

namespace Persons.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _context.ChangeTracker.LazyLoadingEnabled = false;
        }


        public virtual void Add(TEntity obj)
        {
            _dbSet.Add(obj);
        }

        public virtual async Task AddAsync(TEntity obj)
        {
            await Task.Run(() => _dbSet.AddAsync(obj));
        }

        public virtual void Update(TEntity obj)
        {
            _dbSet.Update(obj);
        }

        public virtual async Task UpdateAsync(TEntity obj)
        {
            await Task.Run(() => _dbSet.Update(obj));
        }

        public virtual TEntity GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }
        public virtual async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return await Task.Run(() => _dbSet);
        }

        public void Remove(long id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
