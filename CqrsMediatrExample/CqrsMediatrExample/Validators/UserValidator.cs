using CqrsMediatrExample.DataStore;
using FluentValidation;

namespace CqrsMediatrExample.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .WithMessage("{PropertyName} should be not empty. NEVER!")
            .NotNull()
            .WithMessage("{PropertyName} should be not null. NEVER!");
        RuleFor(u => u.FirstName)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .Length(2,25);
        RuleFor(u => u.Role)
            .NotNull()
            .Must((user, role) => IsValidRole(user))
            .WithMessage("{PropertyName} should be User only.");
        RuleFor(u => u.Email)
            .EmailAddress();

    }

    private bool IsValidRole(User role)
    {
        return role.Role.Equals(Role.USER);
    }
}