using EFTestCodeFirst.DAL.Repositories;
using EFTestCodeFirst.Services.Models;

namespace EFTestCodeFirst.Services;

public interface IUserService
{
    public Task<User> GetUser(string userId);

    public Task<string> AddUser(User user);

    public Task UpdateUser(User user);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUser(string userId)
    {
        return await _userRepository.GetUser(userId);
    }

    public async Task<string> AddUser(User user)
    {
        return await _userRepository.AddUser(user);
    }

    public async Task UpdateUser(User user)
    {
        await _userRepository.UpdateUser(user);
    }
}