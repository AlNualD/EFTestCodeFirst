using EFTestCodeFirst.DAL.Repositories;
using EFTestCodeFirst.Services.Models;

namespace EFTestCodeFirst.Services;

public interface IGuildService
{
    public Task<string> AddGuild(string characterId, Guild newGuild);
    public Task<Guild> GetGuild(string id);
    public Task<List<Character>> GetGuildMembers(string guildId);
    public Task JoinGuild(string guildId, string characterId);
    public Task UpdateGuildDescription(string guildId, string description);
    public Task ChangeMoney(string id, int money);
    public Task AddMoney(string id, int money);
    public Task DeleteGuild(string id);
}

class GuildService : IGuildService
{
    private readonly IGuildRepository _guildRepository;
    private readonly ICharacterRepository _characterRepository;

    public GuildService(IGuildRepository guildRepository, ICharacterRepository characterRepository)
    {
        _guildRepository = guildRepository;
        _characterRepository = characterRepository;
    }

    public Task<string> AddGuild(string characterId, Guild newGuild)
    {
        return _guildRepository.CreateGuild(characterId, newGuild);
    }

    public Task<Guild> GetGuild(string id)
    {
        return _guildRepository.GetGuild(id);
    }

    public Task<List<Character>> GetGuildMembers(string guildId)
    {
        return _characterRepository.GetCharacterByGuild(guildId);
    }

    public async Task JoinGuild(string guildId, string characterId)
    {
        await _guildRepository.JoinGuild(guildId, characterId);
    }

    public async Task UpdateGuildDescription(string guildId, string description)
    {
        await _guildRepository.UpdateGuildDescription(guildId, description);
    }

    public async Task ChangeMoney(string id, int money)
    {
        await _guildRepository.ChangeMoney(id, money);
    }

    public async Task AddMoney(string id, int money)
    {
        await _guildRepository.AddMoney(id, money);
    }

    public async Task DeleteGuild(string id)
    {
        await _guildRepository.DeleteGuild(id);
    }
}