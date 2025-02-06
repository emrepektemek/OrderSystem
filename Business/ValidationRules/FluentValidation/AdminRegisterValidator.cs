using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AdminRegisterValidator : AbstractValidator<AdminRegisterDto>
    {

        public AdminRegisterValidator()
        {
            RuleFor(u => u.Email).EmailAddress().WithMessage("Invalid email address.");

            RuleFor(u => u.Email).NotEmpty().WithMessage("Email is required.");

            RuleFor(u => u.Email).MaximumLength(50).WithMessage("Email cannot exceed 50 characters.");


            RuleFor(u => u.Password).NotEmpty().WithMessage("Password is required.");

            RuleFor(u => u.Password).MinimumLength(4).WithMessage("Password must be at least 4 characters long.");


            RuleFor(u => u.FirstName).NotEmpty().WithMessage("First name is required.");

            RuleFor(u => u.FirstName).MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");


            RuleFor(u => u.LastName).NotEmpty().WithMessage("Last name is required.");

            RuleFor(u => u.LastName).MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");


            RuleFor(u => u.PhoneNumber).MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters.");

            RuleFor(u => u.PhoneNumber)
                .Matches(@"^[\d\s\(\)\-\+]+$")
                .WithMessage("Phone number can only contain digits, spaces, parentheses, '-', and '+'.");
        }

    }
}
