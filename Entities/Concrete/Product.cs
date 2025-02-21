﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product: AuditBaseEntity, IEntity
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public int Size { get; set; }  
        public decimal UnitPrice { get; set; }
        public string? Description { get; set; }

    }
}
