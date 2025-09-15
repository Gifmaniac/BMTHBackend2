using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Entities
{
    public abstract class Merchandise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }

        protected Merchandise(int id, string name, decimal price, bool inStock)
        {
            Id = id;
            Name = name;
            Price = price;
            InStock = inStock;
        }

    }


}
