
using App.Domain.Core.General.Dto;
using App.Domain.Core.ItemAgg.Entities;
using App.Domain.Core.UserAgg.Contracts;
using App.Domain.Core.UserAgg.Dtos;
using App.Domain.Core.UserAgg.Entities;

namespace App.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public ResultDto<User> LoginUser(string username, string password)
    {
        var user = _userRepository.FindUser(username);

        if (user == null)
        {
            return new ResultDto<User> { IsSucceed = false, Message = ".نام کاربری یا رمز عبور اشتباه است" };
        }

        if (!PasswordHelper.VerifyPassword(user.Password, password))
        {
            return new ResultDto<User> { IsSucceed = false, Message = ".نام کاربری یا رمز عبور اشتباه است" };
        }

        return new ResultDto<User> { IsSucceed = true, Data = user };
    }
    public ResultDto<bool> RegisterUser(AddUserDto userDto)
    {
        userDto.Password = PasswordHelper.HashPassword(userDto.Password);

        _userRepository.AddUser(userDto);

        return new ResultDto<bool> { IsSucceed = true };
    }
}
