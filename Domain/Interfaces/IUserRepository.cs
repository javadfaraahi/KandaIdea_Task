﻿using KandaIdea_Task.Domain.Entities;
using System.Linq.Expressions;
namespace KandaIdea_Task.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
     Task<User> GetUserWithCity(int id);
     Task<List<User>> GetUsersWithCity();
}
