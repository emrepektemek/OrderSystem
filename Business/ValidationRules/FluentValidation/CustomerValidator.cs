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

            RuleFor(u => u.CustomerName).NotEmpty();

            RuleFor(u => u.CustomerName).MaximumLength(100);

         
            RuleFor(u => u.CustomerName).MaximumLength(255);

            //RuleFor(u => u.CustomerName).Matches(@"^[\p{L} ]+$");


            RuleFor(u => u.Email).EmailAddress();

            RuleFor(u => u.Email).NotEmpty();

            RuleFor(u => u.Email).MaximumLength(100);



            RuleFor(u => u.Address).NotEmpty();

            //RuleFor(u => u.Address).Matches(@"^[\p{L} ]+$");

            RuleFor(u => u.PhoneNumber).NotEmpty();

            RuleFor(u => u.PhoneNumber).MaximumLength(20);

            RuleFor(u => u.PhoneNumber)
            .Matches(@"^[\d\s\(\)\-\+]+$")
            .WithMessage("Telefon numarası yalnızca rakamlar, boşluk, parantez, '-', ve '+' içerebilir.");



        }  
    }
}