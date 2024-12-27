using Sabu.DTOs.Games;
using Sabu.DTOs.Words;
using Sabu.Entities;

namespace Sabu.Services.Abstracts
{
    public interface IGameService
    {
        Task<Guid> CreateAsync(GameCreateDto dto);
        Task<WordForGameDto> Start(Guid id);
        Task Fail(Guid id);
        Task Success(Guid id);
        Task<WordForGameDto> Skip(Guid id);
        Task<GameResultDto> End(Guid id);
        
    }
}
