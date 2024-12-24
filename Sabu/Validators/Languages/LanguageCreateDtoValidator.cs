using FluentValidation;
using Sabu.DTOs.Languages;

namespace Sabu.Validators.Languages
{
    public class LanguageCreateDtoValidator:AbstractValidator<LanguageCreateDto>
    {
        public LanguageCreateDtoValidator()
        {
            RuleFor(x => x.Code)
              .NotEmpty()
                     .WithMessage("Code boş ola bilməz")
              .NotNull()
                     .WithMessage("Code null ola bilməz")
              .Length(2)
                     .WithMessage("Codun uzunluğu 2 yə bərabər olmalıdır");
            RuleFor(x => x.Name)
                .NotEmpty()
                     .WithMessage("Ad boş ola bilməz")
                .NotNull()
                     .WithMessage("Ad null ola bilməz")
                .MaximumLength(32)
                .MinimumLength(3);
            RuleFor(x => x.IconUrl)
                .MaximumLength(800)
                     .WithMessage("Urlin uzunluğu 800 ve ya ondan kicik olmalıdır")
                .Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$")
                     .WithMessage("Url link olmalıdır");
                     

        }
    }
}
