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
    public interface IInventoryService
    {
        IDataResult<List<InventoryReportDto>> GetInventoryReports();

        Inventory GetInvetoryByWarehouseProduct(int warehouseId, int productId);

        Inventory InvetoryStockQuantityReduce(int warehouseId, int productId, int quatity);
    }
}
