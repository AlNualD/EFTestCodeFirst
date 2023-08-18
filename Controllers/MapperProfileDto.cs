using AutoMapper;
using EFTestCodeFirst.Controllers.Models;
using EFTestCodeFirst.Services.Models;

namespace EFTestCodeFirst.Controllers;

public class MapperProfileDto: Profile
{
    public MapperProfileDto()
    {
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<NewUserDto, User>().ReverseMap();
        CreateMap<CharacterDto, Character>().ReverseMap();
        CreateMap<NewCharacterDto, Character>().ReverseMap();
    }
}