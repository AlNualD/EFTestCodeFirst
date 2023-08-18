using AutoMapper;
using EFTestCodeFirst.DAL.Entities;
using EFTestCodeFirst.Services.Models;

namespace EFTestCodeFirst.DAL;

public class MapperProfileDb: Profile
{
    public MapperProfileDb()
    {
        CreateMap<CharacterDb, Character>().ReverseMap();
        CreateMap<UserDb, User>().ReverseMap();
    }
}