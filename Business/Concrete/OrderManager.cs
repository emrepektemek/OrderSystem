using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Castle.Core.Resource;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
        IWarehouseService _warehouseService;
        IInventoryService _inventoryService;

        public OrderManager(IOrderDal orderDal, 
            IWarehouseService warehouseService, 
            IInventoryService inventoryService)
        {
            _orderDal = orderDal;   
            _warehouseService = warehouseService;   
            _inventoryService = inventoryService;
                
        }

        [SecuredOperation("user")]

        [ValidationAspect(typeof(OrderAddValidator))]
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
                IsApproved = null,               
            };


            _orderDal.Add(orderObject);

            return new SuccessResult(Messages.OrderCreated);
        }

        public IDataResult<List<OrderReportDto>> GetOrderReports()
        {
            return new SuccessDataResult<List<OrderReportDto>>(_orderDal.GetOrderReports());
        }

        public IDataResult<List<UserOrderOrderReportDto>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<UserOrderOrderReportDto>>(_orderDal.GetUserOrderReports(customerId));
        }

        [SecuredOperation("admin,customer.representative,user")]
        public IDataResult<List<OrderApproveDto>> GetOrderApproves()
        {
            return new SuccessDataResult<List<OrderApproveDto>>(_orderDal.GetOrderApproves());
        }

        [SecuredOperation("admin,customer.representative")]
        public IResult UpdateIsApprovedFalse(OrderUpdateApproveRejectDto orderUpdateApproveRejectDto)
        {
            var updatedOrder = _orderDal.UpdateIsApprovedFalse(orderUpdateApproveRejectDto);

            if(updatedOrder != null)
            {                
             return new SuccessResult(Messages.OrderIsApprovedRejected);
            }

            return new ErrorResult(Messages.OrderNotExist);
           
        }

        [SecuredOperation("admin,customer.representative")]

        [ValidationAspect(typeof(OrderApproveAcceptValidator))]
        public IResult UpdateIsApprovedTrue(OrderUpdateApproveAcceptDto orderUpdateApproveAcceptDto)
        {

            IResult result = BusinessRules.Run(
               CheckIfWarehouseExists(orderUpdateApproveAcceptDto.WarehouseId),
               CheckIventoryQuantity(orderUpdateApproveAcceptDto.WarehouseId, orderUpdateApproveAcceptDto.ProductId, orderUpdateApproveAcceptDto.Quantity)
            );

            if (result != null)
            {
                return result;
            }

            var updatedOrder = _orderDal.UpdateIsApprovedTrue(orderUpdateApproveAcceptDto);

            if (updatedOrder != null)
            {
                return new SuccessResult(Messages.OrderIsApprovedAccept);
            }

            return new ErrorResult(Messages.OrderNotExist);
        }


        public IResult CheckIfWarehouseExists(int warehouseId)
        {

            var warehouse = _warehouseService.GetWarehouseById(warehouseId);

            if(warehouse == null)
            {
                return new ErrorResult(Messages.WarehouseNotExist);
            }

            return new SuccessResult();

        }

        public IResult CheckIventoryQuantity(int warehouseId, int productId, int quantity)
        {

            if (warehouseId == null || productId == null)
            {
                return new ErrorResult(Messages.IventoryNotExist);
            }

            var iventory = _inventoryService.GetInvetoryByWarehouseProduct(warehouseId, productId);

            if (iventory == null)
            {
                return new ErrorResult(Messages.IventoryNotExist);
            }

            if(iventory.StockQuantity == 0)
            {
                return new ErrorResult(Messages.IventoryZeroProduct);
            }

            if(quantity > iventory.StockQuantity)
            {
                return new ErrorResult(Messages.IventoryNotEnoughProduct);
            }

            var result = InvetoryStockQuantityReduce(warehouseId, productId, quantity);

            if (result.Success == false)
            {
                return result;
            }

            return new SuccessResult();

        }

        public IResult InvetoryStockQuantityReduce(int warehouseId, int productId, int quantity)
        {

            var iventory = _inventoryService.InvetoryStockQuantityReduce(warehouseId, productId, quantity);

            if (iventory == null)
            {
                return new ErrorResult(Messages.IventoryNotReduced);
            }

            return new SuccessResult();

        }

    }

}
