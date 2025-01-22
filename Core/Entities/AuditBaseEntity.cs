using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public abstract class AuditBaseEntity: IEntity
    {

        [JsonIgnore] 
        public int Id { get; set; }   
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastUpdatedUserId { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }

    }

}
