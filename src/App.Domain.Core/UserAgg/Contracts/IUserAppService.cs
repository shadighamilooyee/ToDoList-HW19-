
using App.Domain.Core.General.Dto;
using App.Domain.Core.ItemAgg.Entities;
using App.Domain.Core.UserAgg.Dtos;
using App.Domain.Core.UserAgg.Entities;

namespace App.Domain.Core.UserAgg.Contracts;

public interface IUserAppService
{
    ResultDto<User> LoginUser(string username, string password);
    ResultDto<bool> RegisterUser(AddUserDto userDto);
}
