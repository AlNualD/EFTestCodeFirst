using AutoMapper;
using EFTestCodeFirst.Controllers.Models;
using EFTestCodeFirst.Services;
using EFTestCodeFirst.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFTestCodeFirst.Controllers;

[ApiController]
[Route("[controller]")]
public class CharacterController: Controller
{
    private readonly ICharacterService _characterService;
    private readonly IMapper _mapper;


    public CharacterController(ICharacterService characterService, IMapper mapper)
    {
        _characterService = characterService;
        _mapper = mapper;
    }

    [HttpGet("{characterId}")]
    public async Task<CharacterDto> GetCharacter(string characterId)
    {
        var character = await _characterService.GetCharacter(characterId);

        return _mapper.Map<CharacterDto>(character);
    }

    [HttpGet("by-user/{userId}")]
    public async Task<List<CharacterDto>> GetCharacterByUser(string userId)
    {
        var characters = await _characterService.GetCharacterByUser(userId);

        return _mapper.Map<List<CharacterDto>>(characters);
    }

    [HttpPut(Name = "AddCharacter")]
    public async Task<string> AddCharacter(string userId, NewCharacterDto newCharacter)
    {
        return await _characterService.AddCharacter(userId,_mapper.Map<Character>(newCharacter));
    }

    [HttpPost(Name = "UpdateCharacter")]
    public async Task UpdateCharacter(CharacterDto character)
    {
        await _characterService.UpdateCharacter(_mapper.Map<Character>(character));
    }

    [HttpDelete(Name = "DeleteCharacter")]
    public async Task DeleteChatacter(string id)
    {
        await _characterService.DeleteCharacter(id);
    }
}