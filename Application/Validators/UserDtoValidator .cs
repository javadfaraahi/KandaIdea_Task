using FluentValidation;
using KandaIdea_Task.Application.DTOs;

namespace KandaIdea_Task.Application.Validators
{
    public class UserDtoValidator:AbstractValidator<UserCreateDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x=>x.FirstName).NotEmpty().WithMessage("First name is required")
                .Length(2, 50).WithMessage("First name must be between 2 and 50 characters.");
            RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .Length(2, 50).WithMessage("Last name must be between 2 and 50 characters.");
            RuleFor(x => x.PhoneNumber)
           .NotEmpty().WithMessage("Phone number is required.")
           .Matches(@"^0\d{10}$").WithMessage("Phone number must start with 0 and have 11 digits.");
            RuleFor(x => x.CityName).NotEmpty().WithMessage("City name is required");
        }
    }
}
