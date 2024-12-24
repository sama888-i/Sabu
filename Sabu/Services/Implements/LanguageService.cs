using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Sabu.DAL;
using Sabu.DTOs.Languages;
using Sabu.Entities;
using Sabu.Exceptions.Languages;
using Sabu.Services.Abstracts;

namespace Sabu.Services.Implements
{
    public class LanguageService(SabuDbContext _context,IMapper _mapper) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            if (await _context.Languages.AnyAsync(x => x.Code == dto.Code))
                throw new LanguageExistException();
            await _context.Languages.AddAsync(_mapper.Map<Language>(dto));
          
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        { 
            var datas= await _context.Languages.ToListAsync();
            return _mapper.Map<IEnumerable<LanguageGetDto>>(datas);

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
        public async Task<LanguageGetDto> GetByCodeLangAsync(string code)
        {
            var language = await _context.Languages.FirstOrDefaultAsync(x => x.Code == code);
            if (language == null) return null;
            return new LanguageGetDto
            {
                Code =language .Code ,
                Name = language.Name,
                Icon = language.Icon

            };
        }
    }
}
