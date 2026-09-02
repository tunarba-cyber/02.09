using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaModular.Modules.Products.Entities
{
    public class Size : BaseAccountableEntity
    {
        public string Name { get; set; } = string.Empty;

        // Navigation property for many-to-many relationship
        public ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
    }
}
