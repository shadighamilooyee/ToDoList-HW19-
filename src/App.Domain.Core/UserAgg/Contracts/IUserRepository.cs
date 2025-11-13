
using App.Domain.Core.UserAgg.Dtos;
using App.Domain.Core.UserAgg.Entities;

namespace App.Domain.Core.UserAgg.Contracts;

public interface IUserRepository
{
    User? FindUser(string username);
    void AddUser(AddUserDto userDto);
}
