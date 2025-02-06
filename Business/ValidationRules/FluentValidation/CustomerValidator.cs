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
    public class CustomerValidator: AbstractValidator<Customer>
    {
        public CustomerValidator() {

            RuleFor(u => u.CustomerName).NotEmpty().WithMessage("Customer name is required.");

            RuleFor(u => u.CustomerName).MaximumLength(100).WithMessage("Customer name cannot exceed 100 characters.");

            RuleFor(u => u.CustomerName).MaximumLength(255) .WithMessage("Customer name cannot exceed 255 characters.");


            RuleFor(u => u.Email).NotEmpty().WithMessage("Email is required.");

            RuleFor(u => u.Email).EmailAddress().WithMessage("Invalid email address.");

            RuleFor(u => u.Email).MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");


            RuleFor(u => u.Address).NotEmpty().WithMessage("Address is required.");


            RuleFor(u => u.PhoneNumber).NotEmpty() .WithMessage("Phone number is required.");

            RuleFor(u => u.PhoneNumber).MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters.");

            RuleFor(u => u.PhoneNumber)
                .Matches(@"^[\d\s\(\)\-\+]+$")
                .WithMessage("Phone number can only contain digits, spaces, parentheses, '-', and '+'.");




        }
    }
}