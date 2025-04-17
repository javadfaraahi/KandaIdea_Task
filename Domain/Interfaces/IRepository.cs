using KandaIdea_Task.Domain.Entities;
using System.Linq.Expressions;

namespace KandaIdea_Task.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> QueryWithIncludes(Expression<Func<T, bool>> predicate = null ,
            params Expression<Func<T, object>>[] includes);
        IQueryable<T> AsQueryable();
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<List<T>> GetByConditionAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(int id);
        Task DeleteRangeAsync(List<int> Ids);
        Task UpdateAsync(T entity);
        Task SaveChangesAsync();

    }
}
