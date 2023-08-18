using AutoMapper;
using EFTestCodeFirst.Controllers.Models;
using EFTestCodeFirst.Services;
using EFTestCodeFirst.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFTestCodeFirst.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetUserInfo")]
    public async Task<UserDto> GetUser(string userId)
    {
        var user = await _userService.GetUser(userId);

        return _mapper.Map<UserDto>(user);
    }

    [HttpPut(Name = "AddUser")]
    public async Task<string> AddUser(NewUserDto newUser)
    {
        return await _userService.AddUser(_mapper.Map<User>(newUser));
    }

    [HttpPost(Name = "UpdateUser")]
    public async Task UpdateUser(UserDto user)
    {
        await _userService.UpdateUser(_mapper.Map<User>(user));
    }
}