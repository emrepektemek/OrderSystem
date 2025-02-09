using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;   
                
        }

        [SecuredOperation("user")]

        [ValidationAspect(typeof(OrderValidator))]
        public IResult Add(Order order)
        {

            var orderObject = new Order
            {
                CustomerId = order.CustomerId,
                ProductId = order.ProductId,    
                Quantity = order.Quantity,
                ShippingAddress = order.ShippingAddress,
                OrderDate = DateTime.Now,              
                CreatedUserId = order.CreatedUserId,    
                CreatedDate = DateTime.Now,
                Status = true,
                IsDeleted = false,
                IsApproved = false,
               
            };


            _orderDal.Add(orderObject);

            return new SuccessResult(Messages.OrderCreated);
        }

        public IDataResult<List<OrderReportDto>> GetOrderReports()
        {
            return new SuccessDataResult<List<OrderReportDto>>(_orderDal.GetOrderReports());
        }

        public IDataResult<List<OrderReportDto>> GetByUserId()
        {
            return new SuccessDataResult<List<OrderReportDto>>(_orderDal.GetOrderReports());
        }

    }

}
