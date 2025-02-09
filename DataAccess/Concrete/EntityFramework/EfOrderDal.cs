using Core.DataAccess.EntityFramework;
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
    }
}
