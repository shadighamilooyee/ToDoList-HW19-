
using App.Domain.Core.UserAgg.Contracts;
using App.Domain.Core.UserAgg.Dtos;
using App.Domain.Core.UserAgg.Entities;
using App.Infra.Db.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repo.Ef;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;
    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public User? FindUser(string username)
    {
        return _dbContext.Users
            .AsNoTracking()
            .FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
    }
    public void AddUser(AddUserDto userDto)
    {
        var user = new User
        {
            Username = userDto.Username,
            Password = userDto.Password,
        };
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }
}
