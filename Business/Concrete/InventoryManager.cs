using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InventoryManager : IInventoryService
    {
        IInventoryDal _inventoryDal;


        public InventoryManager(IInventoryDal inventoryDal)
        {
            _inventoryDal = inventoryDal;
        }

        public IDataResult<List<InventoryReportDto>> GetInventoryReports()
        {
           return new SuccessDataResult<List<InventoryReportDto>> (_inventoryDal.GetInventoryReports());
        }

        public Inventory GetInvetoryByWarehouseProduct(int warehouseId, int productId)
        {
            return _inventoryDal.Get(i => i.WarehouseId == warehouseId && i.ProductId == productId);
        }

        public Inventory InvetoryStockQuantityReduce(int warehouseId, int productId, int quantity)
        {
            return _inventoryDal.InvetoryStockQuantityReduce(warehouseId, productId, quantity);
        }
    }
}
