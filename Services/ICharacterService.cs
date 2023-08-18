using EFTestCodeFirst.DAL.Repositories;
using EFTestCodeFirst.Services.Models;

namespace EFTestCodeFirst.Services;

public interface ICharacterService
{
    public Task<Character> GetCharacter(string id);
    public Task<List<Character>> GetCharacterByUser(string userId);
    public Task<string> AddCharacter(string userId, Character character);
    public Task UpdateCharacter(Character character);
    public Task DeleteCharacter(string id);
}

class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _characterRepository;

    public CharacterService(ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }

    public async Task<Character> GetCharacter(string id)
    {
        return await _characterRepository.GetCharacter(id);
    }

    public async Task<List<Character>> GetCharacterByUser(string userId)
    {
        return await _characterRepository.GetCharacterByUser(userId);
    }

    public async Task<string> AddCharacter(string userId, Character character)
    {
        return await _characterRepository.AddCharacter(userId, character);
    }

    public async Task UpdateCharacter(Character character)
    {
        await _characterRepository.UpdateCharacter(character);
    }

    public async Task DeleteCharacter(string id)
    {
        await _characterRepository.DeleteCharacter(id);
    }
}