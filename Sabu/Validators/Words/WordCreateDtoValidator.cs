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
            RuleFor(x => x.BannedWords)
              .NotEmpty()
                     .WithMessage("BanWord boş ola bilməz")
              .NotNull()
                    .WithMessage("BanWord null ola bilməz");
              



        }
    }
}
