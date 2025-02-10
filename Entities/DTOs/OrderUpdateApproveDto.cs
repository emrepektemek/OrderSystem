using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class OrderUpdateApproveRejectDto: IDto
    {
        public int Id { get; set; }
        public bool? IsApproved { get; set; }
        public int? LastUpdatedUserId { get; set; }
    }
}
