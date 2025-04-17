using KandaIdea_Task.Domain.Entities;
using System.Linq.Expressions;
namespace KandaIdea_Task.Infrastructure.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> GetAsync(int id);
    Task<List<User>> GetPatientsByConditionAsync(Expression<Func<User, bool>> predicate);
    Task AddAsync(User user);   
    Task DeleteAsync(int id);
    Task UpdateAsync(User user);

}
