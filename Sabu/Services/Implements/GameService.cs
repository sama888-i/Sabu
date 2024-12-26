using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Sabu.DAL;
using Sabu.DTOs.Games;
using Sabu.DTOs.Words;
using Sabu.Entities;
using Sabu.Exstensions;
using Sabu.Services.Abstracts;

namespace Sabu.Services.Implements
{
    public class GameService(SabuDbContext _context,IMapper _mapper,IMemoryCache _cache) : IGameService
    {
        private WordForGameDto currentWord;

        public async Task<Guid> CreateAsync(GameCreateDto dto)
        {
            var game = _mapper.Map<Game>(dto);
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }
        public async Task<WordForGameDto> Start(Guid id)
        {
            var game = await _context.Games.FindAsync(id);
            if(game==null||game.Score!=null)
            {
                throw new Exception();

            }
            IQueryable<Word> query = _context.Words           
                .Where(x => x.LanguageCode == game.LanguageCode);
            var words = await query
                .Select(x => new WordForGameDto
                {
                    Id=x.Id ,
                    Word = x.Text,
                    BannedWords = x.BannedWords.Select(y => y.Text)
                })
                .Random(await query.CountAsync())
                .Take(20)
                .ToListAsync();
            var wordStack = new Stack<WordForGameDto>(words);
            WordForGameDto currentWord = wordStack.Pop();
            GameStatusDto status = new GameStatusDto()
            {
                Fail = 0,
                Success =0,
                Skip=0,
                Words=wordStack ,
                MaxSkipCount = game.SkipCount,
                UsedWordIds =words.Select(x=>x.Id)
               
            };
            _cache.Set(id, status,TimeSpan.FromSeconds(300));
            return currentWord;

        }


        public Task End(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Fail(Guid id)
        {
            var status = _getCurrentGame(id);
            
            status.Fail++;
            status.Words.Pop();
            _cache.Set(id, status, TimeSpan.FromSeconds(300));
            
        }

        public async Task<WordForGameDto> Skip(Guid id)
        {
            var status =_getCurrentGame(id);
            if (status.Skip <= status.MaxSkipCount)
            {
                var currentWord = status.Words.Pop();
                status.Skip++;
                _cache.Set(id, status,TimeSpan.FromSeconds(300));
            }
            return null;
        }

     
        public Task Success(Guid id)
        {
            throw new NotImplementedException();
        }
        GameStatusDto _getCurrentGame(Guid id)
        {
            var result = _cache.Get<GameStatusDto>(id);
            if (result == null) throw new Exception();
            return result;
        }
    }
}
