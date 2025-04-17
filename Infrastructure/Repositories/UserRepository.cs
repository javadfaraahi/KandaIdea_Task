using KandaIdea_Task.Domain.Entities;
using KandaIdea_Task.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var userToDelete = await GetAsync(id);
        if (userToDelete is not null) 
        {
            userToDelete.isDeleted = true;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetAsync(int id)
    {
       return await _context.Users.FindAsync(id);
    }

    public async Task<List<User>> GetUsersByConditionAsync(Expression<Func<User, bool>> predicate)
    {
        return await _context.Users.Where(predicate).ToListAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}
