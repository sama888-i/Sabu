using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Sabu.DAL;
using Sabu.DTOs.Languages;
using Sabu.Services.Abstracts;

namespace Sabu.Services.Implements
{
    public class LanguageService(SabuDbContext _context) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            await _context.Languages.AddAsync(new Entities.Language
            {
                Code =dto.Code,
                Name =dto.Name,
                Icon=dto.Icon 

            });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            return await _context.Languages.Select(x => new LanguageGetDto
            {
                Code=x.Code ,
                Name =x.Name ,
                Icon =x.Icon 
            }).ToListAsync();
        }
        public async Task<LanguageGetDto> UpdateAsync(string code,LanguageUpdateDto dto)
        {
            var language = await _context.Languages.FirstOrDefaultAsync(x => x.Code == code);
            if (language == null) return null;
            language.Name = dto.Name;
            language.Icon = dto.Icon;
            await _context.SaveChangesAsync();
            return new LanguageGetDto 
            {
                Code=language.Code ,
                Name =language.Name ,
                Icon=language .Icon 
            };

        }
        public async Task<bool>DeleteAsync(string code)
        {
           var language= await _context.Languages.FirstOrDefaultAsync(x => x.Code == code);
            if (language == null) return false;
            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
