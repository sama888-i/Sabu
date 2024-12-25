using AutoMapper;
using Sabu.DTOs.Games;
using Sabu.Entities;

namespace Sabu.Profiles
{
    public class GameProfile:Profile
    {
        public GameProfile()
        {
            CreateMap<GameCreateDto, Game>();
        }
    }
}
