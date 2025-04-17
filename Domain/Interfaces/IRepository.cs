using KandaIdea_Task.Domain.Entities;
using System.Linq.Expressions;

namespace KandaIdea_Task.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> AsQueryable();
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<List<T>> GetByConditionAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
        Task SaveChangesAsync();

    }
}
