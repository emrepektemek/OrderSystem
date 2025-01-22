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
        public int Id { get; set; } = 0;    
        public int CreatedUserId { get; set; } = 0; 
        public DateTime CreatedDate { get; set; } = DateTime.Now;   
        public int LastUpdatedUserId { get; set; } = 0;
        public DateTime LastUpdatedDate { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

    }

}
