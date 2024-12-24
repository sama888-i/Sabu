using Microsoft.EntityFrameworkCore;
using Sabu.DAL;
using Sabu.DTOs.Words;
using Sabu.Exceptions.Languages;
using Sabu.Entities;
using Sabu.Services.Abstracts;
using AutoMapper;
using Sabu.DTOs.Languages;
using Microsoft.AspNetCore.Mvc;
using Sabu.Exceptions.Words;

namespace Sabu.Services.Implements
{
    public class WordService(SabuDbContext _context,IMapper _mapper) : IWordService
    {
        public async Task CreateAsync(WordCreateDto dto)
        {
            if (await _context.Words.AnyAsync(x => x.Text == dto.Text))
                throw new WordTextException();
            await _context.Words.AddAsync(_mapper.Map<Word>(dto));

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WordGetDto>> GetAllAsync()
        {
            var datas = await _context.Words.Include(w => w.BannedWords).ToListAsync();
            return _mapper.Map<IEnumerable<WordGetDto>>(datas);
        }
        public async Task<bool> DeleteAsync(string text)
        {
            var word = await _context.Words.FirstOrDefaultAsync(x => x.Text ==text);
            if (word == null)
                throw new WordNotFoundException();
            _context.Words.Remove(word);
            await _context.SaveChangesAsync();
            return true;


        }
        public async Task UpdateAsync(string text,WordUpdateDto dto)
        {
            var word = await _context.Words.Include(x=>x.BannedWords).FirstOrDefaultAsync(x=>x.Text ==text);
            if (word == null)
                throw new WordNotFoundException();
            _mapper.Map(dto, word);
            await _context.SaveChangesAsync();
            
        }
    }
}
