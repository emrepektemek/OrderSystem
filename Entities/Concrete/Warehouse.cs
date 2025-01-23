using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Warehouse: AuditBaseEntity, IEntity    
    {
        public string WarehouseName { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }

    }
}
