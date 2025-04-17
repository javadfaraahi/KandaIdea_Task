using KandaIdea_Task.Domain.Entities;
using KandaIdea_Task.Domain.Interfaces;
using KandaIdea_Task.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KandaIdea_Task.Infrastructure.Repositories;

public class UserRepository : Repository<User> , IUserRepository
{


    public UserRepository(AppDbContext context) : base(context)
    {
    }
    
   
    public override async Task DeleteAsync(int id)
    {
        var userToDelete = await GetAsync(id);
        if (userToDelete is not null)
        {
            userToDelete.isDeleted = true;
            await SaveChangesAsync();
        }
    }
    public override async Task DeleteRangeAsync(List<int> Ids)
    {
        var usersToDelete = await GetByConditionAsync(x => Ids.Contains(x.Id));
        foreach (var user in usersToDelete)
        {
            user.isDeleted = true;
        }
        await SaveChangesAsync();
    }

    
    public async Task<User> GetUserWithCity(int id)
    {
        return await _context.Users.Include(x => x.City).FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<List<User>> GetUsersWithCity()
    {
        return await _context.Users.Include(x => x.City).ToListAsync();
    }
}
