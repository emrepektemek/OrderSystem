using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {

            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category ID is required.");

            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Category ID must be greater than zero.");

            RuleFor(x => x.CategoryId).Must(x => x % 1 == 0).WithMessage("Category ID must be an integer.");

            RuleFor(p => p.ProductName).NotEmpty();

            RuleFor(p => p.ProductName).MaximumLength(100);
      
            RuleFor(p => p.Size).GreaterThan(0).WithMessage("Size değeri boş bırakılmamalıdır");


        }
    }

}

