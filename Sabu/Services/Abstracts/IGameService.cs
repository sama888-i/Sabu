using Sabu.DTOs.Games;
using Sabu.Entities;

namespace Sabu.Services.Abstracts
{
    public interface IGameService
    {
        Task<Guid> CreateAsync(GameCreateDto dto);
        Task Start(Guid id);
    }
}
