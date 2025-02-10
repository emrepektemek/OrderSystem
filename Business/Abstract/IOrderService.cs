using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<OrderReportDto>> GetOrderReports();

        IResult Add(Order order);

        IDataResult<List<UserOrderOrderReportDto>> GetByCustomerId(int customerId);

        IDataResult<List<OrderApproveDto>> GetOrderApproves();

        IResult UpdateIsApprovedFalse(OrderUpdateApproveRejectDto orderUpdateApproveRejectDto);

    }
}
