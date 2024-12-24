using Sabu.DTOs.Languages;
using Sabu.DTOs.Words;

namespace Sabu.Services.Abstracts
{
    public interface IWordService
    {
        Task CreateAsync(WordCreateDto dto);
        Task<IEnumerable<WordGetDto>> GetAllAsync();
        Task<bool> DeleteAsync(string text);
        Task UpdateAsync(string text,WordUpdateDto dto);
    }
}
