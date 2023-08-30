using AutoMapper;
using EFTestCodeFirst.Controllers.Models;
using EFTestCodeFirst.Services;
using EFTestCodeFirst.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFTestCodeFirst.Controllers;


[ApiController]
[Route("[controller]")]
public class GuildController: Controller
{
    private readonly IGuildService _guildService;
    private readonly IMapper _mapper;


    public GuildController(IGuildService guildService, IMapper mapper)
    {
        _guildService = guildService;
        _mapper = mapper;
    }

    [HttpGet("{guildId}")]
    public async Task<GuildDto> GetGuild(string guildId)
    {
        var guild = await _guildService.GetGuild(guildId);

        return _mapper.Map<GuildDto>(guild);
    }

    [HttpPut(Name = "AddGuild")]
    public async Task<string> AddGuild(string characterId, NewGuildDto newGuild)
    {
        return await _guildService.AddGuild(characterId,_mapper.Map<Guild>(newGuild));
    }

    [HttpPost("join")]
    public async Task JoinGuild(string characterId, string guildId)
    {
        await _guildService.JoinGuild(guildId, characterId);
    }

    [HttpPost("description")]
    public async Task UpdateGuildDescription(string guildId, string description)
    {
        await _guildService.UpdateGuildDescription(guildId, description);
    }

    [HttpPost("SetMoney")]
    public async Task UpdateGuildMoney(string guildId, int money)
    {
        await _guildService.ChangeMoney(guildId, money);
    }

    [HttpPut("AddMoney")]
    public async Task AddGuildMoney(string guildId, int money)
    {
        await _guildService.AddMoney(guildId, money);
    }

    [HttpDelete(Name = "DeleteGuild")]
    public async Task DeleteChatacter(string id)
    {
        await _guildService.DeleteGuild(id);
    }
}