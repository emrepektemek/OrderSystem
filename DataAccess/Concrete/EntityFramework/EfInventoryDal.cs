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
    public class EfInventoryDal : EfEntityRepositoryBase<Inventory, OrderSystemContext>, IInventoryDal
    {

        public List<InventoryReportDto> GetInventoryReports()
        {


            using (OrderSystemContext context = new OrderSystemContext())
            {


                var result = from p in context.Products
                             join i in context.Inventories
                             on p.Id equals i.ProductId
                             join w in context.Warehouses
                             on i.WarehouseId equals w.Id
                             select new InventoryReportDto
                             {
                                 InventoryId = i.Id,
                                 WarehouseId = w.Id,    
                                 WarehouseName = w.WarehouseName,
                                 WarehouseLocation = w.Location,
                                 ProductId = p.Id,
                                 ProductName = p.ProductName,
                                 StockQuantity = i.StockQuantity,                   
                             };

                return result.ToList();

            }

        }

        public Inventory InvetoryStockQuantityReduce(int warehouseId, int productId, int quantity)
        {
            using (OrderSystemContext context = new OrderSystemContext())
            {
                var inventory = context.Inventories
                    .FirstOrDefault(i => i.WarehouseId == warehouseId && i.ProductId == productId);
            
                inventory.StockQuantity -= quantity;

                context.SaveChanges();

                return inventory;
            }
        }

      
    }
}
