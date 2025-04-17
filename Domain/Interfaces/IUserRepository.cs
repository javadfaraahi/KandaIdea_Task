using KandaIdea_Task.Domain.Entities;
using System.Linq.Expressions;
namespace KandaIdea_Task.Domain.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> GetAsync(int id);
    Task<List<User>> GetUsersByConditionAsync(Expression<Func<User, bool>> predicate);
    Task AddAsync(User user);   
    Task DeleteAsync(int id);
    Task UpdateAsync(User user);

}
