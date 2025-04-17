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
   
}
