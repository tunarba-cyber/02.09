using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaModular.Modules.Products.Entities
{
    public class Product : BaseAccountableEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;

        // Foreign key for Category
        public long CategoryId { get; set; }

        // Navigation properties
        public Category Category { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
    }
}
