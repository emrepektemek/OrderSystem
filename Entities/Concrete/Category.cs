using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category:Core.Entities.IEntity
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }    
    }
}
