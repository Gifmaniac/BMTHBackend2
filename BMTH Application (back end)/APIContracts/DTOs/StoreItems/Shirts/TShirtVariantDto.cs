using Contracts.Enums.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIContracts.DTOs.StoreItems.Shirts
{
    public class TShirtVariantDto
    {
        public string Color { get; set; }
        public Sizes Size { get; set; }
        public int Quantity { get; set; }
    }
}
