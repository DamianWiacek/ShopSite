using FluentValidation;
using ShopSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSite.Models.Validators
{
    public class NewUserDtoValidator : AbstractValidator<NewUserDto>
    {
        public NewUserDtoValidator(ShopDbContext dbContext)
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x =>x.Password).MinimumLength(8).MaximumLength(45);

            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password);

            RuleFor(x => x.Email).Custom((value, context) =>
            {
                if (dbContext.Users.Any(u => u.Email == value))
                {
                    context.AddFailure("Email", "That email is taken");
                }
            });
        }

    }
}
