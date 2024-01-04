using Microsoft.EntityFrameworkCore;
using Reservation.Core.Repositories;
using System.Linq.Expressions;

namespace Reservation.Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet=_context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<TEntity?> GetByIdsAsync(IEnumerable<int> ids)
        {
            var entities = await _dbSet.FindAsync(ids);
            if (entities != null)
                _context.Entry(entities).State = EntityState.Detached;
            return entities;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
