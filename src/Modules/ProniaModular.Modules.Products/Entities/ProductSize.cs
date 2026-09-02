using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaModular.Modules.Products.Entities
{
    public class ProductSize
    {
        public long ProductId { get; set; }
        public long SizeId { get; set; }

        // Navigation properties
        public Product Product { get; set; }
        public Size Size { get; set; }
    }
}
