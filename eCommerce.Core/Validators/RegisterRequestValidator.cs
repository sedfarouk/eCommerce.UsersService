using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        // Email
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is invalid");
        
        // Password
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6);
        
        // PersonName
        RuleFor(x => x.PersonName)
            .NotEmpty().WithMessage("PersonName is required")
            .MaximumLength(50);
        
        // Gender
        RuleFor(x => x.Gender)
            .IsInEnum().WithMessage("Gender is invalid");
    }
}