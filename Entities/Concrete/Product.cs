using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product: AuditBaseEntity
    {

        public int CategoryId { get; set; } = 0;
        public string ProductName { get; set; } = "Product Name";   
        public int? ColorId { get; set; } = 0;   
        public int Size { get; set; } = 0;  
        public decimal UnitPrice { get; set; } = 20;
        public string Description { get; set; } = "Description";

    }
}
