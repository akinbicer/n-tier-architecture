using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class RegisterValidator : AbstractValidator<RegisterDto>
{
    public RegisterValidator()
    {
        RuleFor(p => p.FirstName).Length(2, 50).WithMessage("The name part can be a minimum of 2 and a maximum of 50 characters.").NotEmpty().WithMessage("Name cannot be empty.");
        RuleFor(p => p.LastName).Length(2, 50).WithMessage("The last name part can be at least 2 and at most 50 characters.").NotEmpty().WithMessage("Surname cannot be empty.");
        RuleFor(p => p.MailAddress).EmailAddress().WithMessage("The Email field must be a valid email address.").NotEmpty().WithMessage("The e-mail section cannot be empty.");
        RuleFor(p => p.Username).Length(2, 50).WithMessage("Username can be at least 2 characters and at most 50 characters.").NotEmpty().WithMessage("Username cannot be empty.");
        RuleFor(p => p.Password).Length(2, 50).WithMessage("Password section can be at least 2 and maximum 50 characters.").NotEmpty().WithMessage("Password cannot be empty.");
    }
}