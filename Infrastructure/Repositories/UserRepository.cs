using KandaIdea_Task.Domain.Entities;
using KandaIdea_Task.Infrastructure.Data;
using System.Linq.Expressions;

namespace KandaIdea_Task.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{

    #region Fields
    private readonly AppDbContext _context;
    #endregion
    #region Ctor
    public UserRepository(AppDbContext context)
    {
        _context = context; 
    }
    #endregion
    public Task AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetPatientsByConditionAsync(Expression<Func<User, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}
