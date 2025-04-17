using KandaIdea_Task.Domain.Interfaces;
using KandaIdea_Task.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KandaIdea_Task.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Fields
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        #endregion
        #region Ctor
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>(); 
        }
        #endregion
        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual IQueryable<T> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<List<T>> GetByConditionAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync(); 
        }

        public virtual async Task UpdateAsync(T entity)
        {
             _dbSet.Update(entity);
        }
        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
