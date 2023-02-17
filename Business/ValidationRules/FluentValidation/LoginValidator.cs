using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(p => p.Username).Length(2, 50).WithMessage("Username can be at least 2 characters and at most 50 characters.").NotEmpty().WithMessage("Username cannot be empty.");
        RuleFor(p => p.Password).Length(2, 50).WithMessage("Password section can be at least 2 and maximum 50 characters.").NotEmpty().WithMessage("Password cannot be empty.");
    }
}