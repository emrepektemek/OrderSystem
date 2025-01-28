using Castle.Core.Resource;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthValidator: AbstractValidator<UserForRegisterDto>
    {

        public AuthValidator()
        {
            RuleFor(u => u.Email).EmailAddress();

            RuleFor(u => u.Email).NotEmpty();

            RuleFor(u => u.Password).MinimumLength(6);

            RuleFor(u => u.Password).NotEmpty();

            RuleFor(u => u.FirstName).NotEmpty();

            RuleFor(u => u.LastName).NotEmpty();

        }

    }
}
