using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaModular.Modules.Products.Entities
{
    public class Category : BaseAccountableEntity
    {
        public string Name { get; set; } = string.Empty;

        // Navigation property for one-to-many relationship
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
