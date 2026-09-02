using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaModular.Modules.Products.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public int IsDeleted { get; set; } 
    }
}
