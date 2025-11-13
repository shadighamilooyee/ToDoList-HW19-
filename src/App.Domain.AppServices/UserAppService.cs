
using App.Domain.Core.General.Dto;
using App.Domain.Core.ItemAgg.Entities;
using App.Domain.Core.UserAgg.Contracts;
using App.Domain.Core.UserAgg.Dtos;
using App.Domain.Core.UserAgg.Entities;

namespace App.Domain.AppServices;

public class UserAppService : IUserAppService
{
    private readonly IUserService _userService;
    public UserAppService(IUserService userService)
    {
        _userService = userService;
    }
    public ResultDto<User> LoginUser(string username, string password)
    {
        return _userService.LoginUser(username, password);
    }

    public ResultDto<bool> RegisterUser(AddUserDto userDto)
    {
        return _userService.RegisterUser(userDto);
    }
}
