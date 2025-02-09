using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserOrderOrderReportDto : AuditBaseEntity, IDto
    {
        public string ProductName { get; set; }      
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
