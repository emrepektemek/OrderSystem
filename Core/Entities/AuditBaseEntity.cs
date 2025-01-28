using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public abstract class AuditBaseEntity
    {

        [JsonIgnore]
        public int Id { get; set; }
        public int CreatedUserId { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? LastUpdatedUserId { get; set; } = null;
        public DateTime? LastUpdatedDate { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

    }

}
