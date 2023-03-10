using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;
using SSY.UserDetails.Dtos;
using Volo.Abp.Identity;

namespace SSY.UserDetails
{
    public class UserDetailFluentValidator : AbstractValidator<CreateUserDetailDto>
    {
        private readonly IIdentityUserAppService _userAppService;

        public UserDetailFluentValidator(IIdentityUserAppService userAppService)
        {
            _userAppService = userAppService;
            RuleFor(c => c.FirstName)
                .NotEmpty()
                .WithMessage("First Name is Required");
            RuleFor(c => c.Surname)
                .NotEmpty()
                .WithMessage("Last Name is Required");
            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("Email is Required")
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .MustAsync(EmailAddressMustNotExist)
                .WithMessage("Email is already exists");
            RuleFor(c => c.Password)
                .NotEmpty()
                .WithMessage("Password is Required")
                .MinimumLength(6)
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.)."); ;
        }

        private async Task<bool> EmailAddressMustNotExist(CreateUserDetailDto arg1, string arg2, CancellationToken arg3)
        {
            if (arg2 is not null)
            {
                var res = await _userAppService.FindByEmailAsync(arg2);
                return res is  null;
            }

            return true;
        }
    }
}
