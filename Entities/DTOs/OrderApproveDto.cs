using Core;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class OrderApproveDto: Order, IDto
    {
        //customer
        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerAddress { get; set; }


        // product

        public int ProductId { get; set; }   
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }


        // intentory

        public int WarehouseId { get; set; }

        public int StockQuantity { get; set; }


        // warehouse

        public string WarehouseName { get; set; }

        public string Location { get; set; }



    }
}
