using AutoMapper;
using EFTestCodeFirst.DAL.Entities;
using EFTestCodeFirst.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTestCodeFirst.DAL.Repositories;

public interface ICharacterRepository
{
    public Task<Character> GetCharacter(string id);

    public Task<List<Character>> GetCharacterByUser(string userId);

    public Task<string> AddCharacter(string userId, Character character);

    public Task UpdateCharacter(Character character);

    public Task DeleteCharacter(string id);
}

class CharacterRepository : ICharacterRepository
{
    private readonly ApplicationContext _db;
    private readonly IMapper _mapper;

    public CharacterRepository(ApplicationContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Character> GetCharacter(string id)
    {
        var characterDb = await _db.Characters.FindAsync(id);

        return _mapper.Map<Character>(characterDb);
    }

    public async Task<List<Character>> GetCharacterByUser(string userId)
    {
        var characters = await _db.Characters.Where(c => c.User!.Id == userId)
            .ToListAsync();

        return _mapper.Map<List<Character>>(characters);
    }

    public async Task<string> AddCharacter(string userId, Character character)
    {
        var userDb = await _db.Users.FirstAsync(user => user.Id == userId);
        var characterDb = _mapper.Map<CharacterDb>(character);
        characterDb.User = userDb;

        await _db.AddAsync(characterDb);
        await _db.SaveChangesAsync();

        return characterDb.Id;
    }

    public async Task UpdateCharacter(Character character)
    {
        var characterDb = _mapper.Map<CharacterDb>(character);

        _db.Entry(characterDb).State = EntityState.Modified;
        _db.Entry(characterDb).Property(x => x.User).IsModified = false;
        
        await _db.SaveChangesAsync();
    }

    public async Task DeleteCharacter(string id)
    {
        await _db.Characters.Where(db => db.Id == id).ExecuteDeleteAsync();
    }
}