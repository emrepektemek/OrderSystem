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
    public class OrderApproveAcceptValidator : AbstractValidator<OrderUpdateApproveAcceptDto>
    {
        public OrderApproveAcceptValidator()
        {

            RuleFor(x => x.WarehouseId).NotEmpty().WithMessage("Warehouse is required.");

            RuleFor(x => x.WarehouseId).GreaterThan(0).WithMessage("Warehouse ID must be greater than zero.");

            RuleFor(x => x.WarehouseId).Must(x => x % 1 == 0).WithMessage("Warehouse ID must be an integer.");


            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product is required.");

            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("Product ID must be greater than zero.");

            RuleFor(x => x.ProductId).Must(x => x % 1 == 0).WithMessage("Product ID must be an integer.");

        }
    }
}
