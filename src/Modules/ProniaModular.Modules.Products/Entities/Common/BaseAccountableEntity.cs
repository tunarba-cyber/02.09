using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaModular.Modules.Products.Entities
{
    public abstract class BaseAccountableEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }

        protected BaseAccountableEntity()
        {
            CreatedAt = DateTime.UtcNow;
            CreatedBy = "Admin"; // Default value, can be overridden
            
        }
    }
    
}
