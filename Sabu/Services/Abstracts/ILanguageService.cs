using Sabu.DTOs.Languages;

namespace Sabu.Services.Abstracts
{
    public interface ILanguageService
    {
        Task CreateAsync(LanguageCreateDto dto);
        Task<IEnumerable<LanguageGetDto>> GetAllAsync();
        Task<LanguageGetDto> UpdateAsync(string code,LanguageUpdateDto dto);
        Task<bool> DeleteAsync(string code);
        Task<LanguageGetDto> GetByCodeLangAsync(string code);
    }
}
