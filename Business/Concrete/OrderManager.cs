using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
        public IDataResult<List<OrderReportDto>> GetOrderReports()
        {
            return new SuccessDataResult<List<OrderReportDto>>(_orderDal.GetOrderReports());
        }
    }

}
