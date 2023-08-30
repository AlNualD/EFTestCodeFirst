using AutoMapper;
using EFTestCodeFirst.DAL.Entities;
using EFTestCodeFirst.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTestCodeFirst.DAL.Repositories;

public interface IGuildRepository
{
    public Task<Guild> GetGuild(string id);
    public Task<string> CreateGuild(string leaderId, Guild newGuild);
    public Task UpdateGuildDescription(string id, string description);
    public Task DeleteGuild(string id);
    public Task<string?> GetLeader(string guildId);
    public Task JoinGuild(string guildId, string characterId);
    public Task ChangeMoney(string guildId, int money);
    public Task AddMoney(string guildId, int money);
}

class GuildRepository : IGuildRepository
{
    private readonly ApplicationContext _db;
    private readonly IMapper _mapper;

    public GuildRepository(ApplicationContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Guild> GetGuild(string id)
    {
        var guild = await _db.Guilds.FindAsync(id);

        return _mapper.Map<Guild>(guild);
    }

    public async Task<string> CreateGuild(string leaderId, Guild newGuild)
    {
        var guild = _mapper.Map<GuildDb>(newGuild);
        guild.LeaderId = leaderId;
        _db.Guilds.Add(guild);
        await _db.SaveChangesAsync();
        return guild.Id;
    }

    public async Task UpdateGuildDescription(string id, string description)
    {
        try
        {
            var guild = await _db.Guilds.FindAsync(id);

            if (guild != null)
            {
                guild.Description = description;
                await _db.SaveChangesAsync();
            }
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task DeleteGuild(string id)
    {
        await _db.Guilds.Where(db => db.Id == id).ExecuteDeleteAsync();
    }

    public async Task<string?> GetLeader(string guildId)
    {
        var guild = await _db.Guilds.FindAsync(guildId);

        return guild?.LeaderId;
    }

    public async Task JoinGuild(string guildId, string characterId)
    {
        var characterDb = await _db.Characters.FindAsync(characterId);
        var guildDb = await _db.Guilds.FindAsync(guildId);
        if (characterDb == null) throw new ArgumentException();
        
        characterDb.Guild = guildDb;

        await _db.SaveChangesAsync();
    }

    public async Task ChangeMoney(string guildId, int money)
    {
        try
        {
            var guild = await _db.Guilds.FindAsync(guildId);

            if (guild != null)
            {
                guild.Gold = money;
                await _db.SaveChangesAsync();
            }
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task AddMoney(string guildId, int money)
    {
        await using var transaction = await _db.Database.BeginTransactionAsync();

        var guild = await _db.Guilds.FindAsync(guildId);

        if (guild != null)
        {
            guild.Gold += money;
            await _db.SaveChangesAsync();
        }
        await transaction.CommitAsync();
    }
}