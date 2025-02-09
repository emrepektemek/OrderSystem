using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product is required.");

            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("Product ID must be greater than zero.");

            RuleFor(x => x.ProductId).Must(x => x % 1 == 0).WithMessage("Product ID must be an integer.");


            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity required");

            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(1).WithMessage("Quantity required.");

            RuleFor(x => x.Quantity).LessThanOrEqualTo(10).WithMessage("You can order a maximum of 10 quantity.");



            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer is required.");

            RuleFor(x => x.CustomerId).NotNull().WithMessage("Customer is required.");

            RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("Customer ID must be greater than zero.");

            RuleFor(x => x.CustomerId).Must(x => x % 1 == 0).WithMessage("Customer ID must be an integer.");



        }
    }
}
