using AutoMapper;
using Sabu.DAL;
using Sabu.DTOs.Games;
using Sabu.Entities;
using Sabu.Services.Abstracts;

namespace Sabu.Services.Implements
{
    public class GameService(SabuDbContext _context,IMapper _mapper) : IGameService
    {
        public async Task<Guid> CreateAsync(GameCreateDto dto)
        {
            var game = _mapper.Map<Game>(dto);
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }

        public Task Start(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
