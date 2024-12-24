using AutoMapper;
using Sabu.DTOs.BannedWords;
using Sabu.DTOs.Words;
using Sabu.Entities;

namespace Sabu.Profiles
{
    public class WordProfile:Profile
    {
        public WordProfile()
        {
            CreateMap<WordCreateDto, Word>()
                 .ForMember(w => w.BannedWords , bwd=>bwd.MapFrom(x => x.BannedWords.Select (bwd=>new BannedWord { Text =bwd.Text }).ToList ()));
            CreateMap<BannedWord, BannedWordCreateDto>().ReverseMap();
          
                 
            CreateMap<Word, WordGetDto>()
                .ForMember(w => w.BannedWords, bwd => bwd.MapFrom(x => x.BannedWords));
            CreateMap <WordUpdateDto ,Word>()
                .ForMember(w => w.BannedWords, bwd => bwd.MapFrom(x => x.BannedWords.Select(bwd => new BannedWord { Text = bwd.Text }).ToList()));
            

        }
    }
}
