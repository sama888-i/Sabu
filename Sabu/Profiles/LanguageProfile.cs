using AutoMapper;
using Sabu.DTOs.Languages;
using Sabu.Entities;

namespace Sabu.Profiles
{
    public class LanguageProfile:Profile
    {
        public LanguageProfile()
        {
            CreateMap<LanguageCreateDto, Language>()
                    .ForMember(l => l.Icon, lcd => lcd.MapFrom(x => x.IconUrl));
            CreateMap<Language, LanguageGetDto>();
                    
        }
    }
}
