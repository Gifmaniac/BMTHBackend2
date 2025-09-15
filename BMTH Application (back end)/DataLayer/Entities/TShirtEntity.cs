using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class TShirtEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
        public int TotalQuantity { get; set; }

        public List<TShirtVariantEntity> Variants { get; set; } = new();
    }
}
