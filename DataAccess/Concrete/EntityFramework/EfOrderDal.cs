using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, OrderSystemContext>, IOrderDal
    {
        public List<OrderApproveDto> GetOrderApproves()
        {
            using (OrderSystemContext context = new OrderSystemContext())
            {

                var result = from o in context.Orders
                             join c in context.Customers
                             on o.CustomerId equals c.Id 

                             join p in context.Products
                             on o.ProductId equals p.Id 
                       
                             where o.IsApproved == null

                             orderby o.OrderDate ascending                         
                             select new OrderApproveDto
                             {
                                 Id = o.Id,
                                 CreatedUserId = o.CreatedUserId,
                                 CreatedDate = o.CreatedDate,   
                                 LastUpdatedUserId = o.LastUpdatedUserId,
                                 LastUpdatedDate = o.LastUpdatedDate,
                                 Status = o.Status,
                                 IsDeleted = o.IsDeleted,
                                 
                                 CustomerId = o.CustomerId,
                                 ProductId = o.ProductId, 
                                 Quantity = o.Quantity,
                                 OrderDate = o.OrderDate,
                                 ShipDate = o.ShipDate,
                                 ShippingAddress = o.ShippingAddress,   
                                 IsApproved = o.IsApproved,

                                 CustomerName = c.CustomerName,
                                 CustomerEmail = c.Email,
                                 CustomerAddress = c.Address,
                                 
                                 ProductName = p.ProductName,
                                 UnitPrice = p.UnitPrice,  
                                                              
                            
                             };

                return result.ToList();

            }

        }

        public List<OrderReportDto> GetOrderReports()
        {

            using (OrderSystemContext context = new OrderSystemContext())
            {

                var result = from o in context.Orders
                             join p in context.Products
                             on o.ProductId equals p.Id into productGroup
                             from p in productGroup.DefaultIfEmpty() 

                             join c in context.Customers
                             on o.CustomerId equals c.Id into customerGroup
                             from c in customerGroup.DefaultIfEmpty() 

                             orderby o.OrderDate descending, 
                             o.IsApproved ascending,
                             o.Status descending
                             select new OrderReportDto
                             {
                                 OrderId = o.Id,
                                 CustomerName = c.CustomerName,
                                 ProductName = p.ProductName,
                                 CustomerAddress = c.Address,
                                 CustomerPhoneNumber = c.PhoneNumber,
                                 CustomerEmail = c.Email,
                                 Quantity = o.Quantity,
                                 OrderDate = o.OrderDate,
                                 ShipDate = o.ShipDate,
                                 OrderStatus = o.Status,
                                 IsApproved = o.IsApproved, 
                             };

                return result.ToList();

            }
        }

        public List<UserOrderOrderReportDto> GetUserOrderReports(int customerId)
        {
            using (OrderSystemContext context = new OrderSystemContext())
            {

                var result = from o in context.Orders
                             join p in context.Products
                             on o.ProductId equals p.Id into productGroup
                             from p in productGroup.DefaultIfEmpty()
                             where o.CustomerId == customerId
                             orderby o.OrderDate descending,
                             o.IsApproved ascending,
                             o.Status descending
                             select new UserOrderOrderReportDto
                             {
                                 ProductName = p.ProductName,
                                 Quantity = o.Quantity,
                                 UnitPrice = p.UnitPrice,
                                 OrderDate = o.OrderDate,
                                 ShipDate = o.ShipDate, 
                                 IsApproved= o.IsApproved,
                                 Status = o.Status,                              
                             };

                return result.ToList();

            }

            
        }

        public Order UpdateIsApprovedFalse(OrderUpdateApproveRejectDto orderUpdateApproveRejectDto)
        {
            using (var context = new OrderSystemContext())
            {
                var order = context.Orders.Find(orderUpdateApproveRejectDto.Id);

                if (order == null) {

                    return null;

                }

                order.IsApproved = orderUpdateApproveRejectDto.IsApproved;
                order.LastUpdatedUserId = orderUpdateApproveRejectDto.LastUpdatedUserId;
                order.LastUpdatedDate = DateTime.Now;

                context.SaveChanges();

                return order;

            }
          
        }

        public Order UpdateIsApprovedTrue(OrderUpdateApproveAcceptDto orderUpdateApproveAcceptDto)
        {

            using (var context = new OrderSystemContext())
            {
                var order = context.Orders.Find(orderUpdateApproveAcceptDto.Id);

                if (order == null)
                {

                    return null;

                }

                order.IsApproved = orderUpdateApproveAcceptDto.IsApproved;
                order.LastUpdatedUserId = orderUpdateApproveAcceptDto.LastUpdatedUserId;
                order.LastUpdatedDate = DateTime.Now;

                context.SaveChanges();

                return order;

            }
        }
    }
}


