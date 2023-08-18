using EFTestCodeFirst.Services.Models;
using AutoMapper;
using EFTestCodeFirst.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFTestCodeFirst.DAL.Repositories;

public interface IUserRepository
{
    public Task<User> GetUser(string userId);

    public Task UpdateUser(User user);

    public Task<string> AddUser(User user);
}

class UserRepository : IUserRepository
{
    private readonly ApplicationContext _db;
    private readonly IMapper _mapper;

    public UserRepository(ApplicationContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<User> GetUser(string userId)
    {
        var user = await _db.Users.FindAsync(userId);

        return _mapper.Map<User>(user);
    }

    public async Task UpdateUser(User user)
    {
        var userDb = _mapper.Map<UserDb>(user);

        _db.Entry(userDb).State = EntityState.Modified;
        _db.Entry(userDb).Property(x => x.Characters).IsModified = false;
        await _db.SaveChangesAsync();
    }

    public async Task<string> AddUser(User user)
    {
        var userDb = _mapper.Map<UserDb>(user);
        await _db.Users.AddAsync(userDb);
        await _db.SaveChangesAsync();

        return userDb.Id;
    }
}