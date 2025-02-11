using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class InventoryReportDto: IDto
    {
        public int InventoryId { get; set; }

        public int WarehouseId { get; set; }

        public string WarehouseName { get; set; }

        public string WarehouseLocation { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int StockQuantity { get; set; }

    }
}
