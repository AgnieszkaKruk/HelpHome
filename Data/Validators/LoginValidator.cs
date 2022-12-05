using Domain.Models;
using FluentValidation;

namespace Data.Validators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator(HelpHomeDbContext helpHomeDbContext)
        {
            RuleFor(e => e.Email).NotEmpty().EmailAddress();
            RuleFor(e => e.Password).NotEmpty();

        }
    }
}
