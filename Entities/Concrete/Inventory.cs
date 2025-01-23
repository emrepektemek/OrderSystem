using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Inventory : AuditBaseEntity, IEntity   
    {
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public int StockQuantity { get; set; }
    }
}
