using FluentValidation;
using Sabu.DTOs.Words;

namespace Sabu.Validators.Words
{
    public class WordCreateDtoValidator:AbstractValidator<WordCreateDto>
    {
        public WordCreateDtoValidator()
        {
            RuleFor(x => x.LanguageCode)
              .NotEmpty()
                     .WithMessage("Code boş ola bilməz")
              .NotNull()
                     .WithMessage("Code null ola bilməz")
              .Length(2);
            RuleFor(x => x.Text)
              .NotEmpty()
                     .WithMessage("Ad boş ola bilməz")
              .NotNull()
                     .WithMessage("Ad null ola bilməz")
              .MaximumLength(32);
            RuleForEach(x => x.BannedWords)
              .NotEmpty()
                     .WithMessage("BanWord boş ola bilməz")
              .NotNull()
                    .WithMessage("BanWord null ola bilməz");

            RuleFor(x => x.BannedWords)
              .NotNull()
                   .WithMessage("BanWord boş ola bilməz")
              .Must(x => x.Count == 6)
                   .WithMessage("BanWord sayi 6 olmalidir");
            
                  






        }
    }
}
