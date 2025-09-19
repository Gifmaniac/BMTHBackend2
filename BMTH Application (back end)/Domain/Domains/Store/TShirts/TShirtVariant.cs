using Contracts.Enums.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domains.Store.TShirts
{
    public class TShirtVariant
    {
        public int VariantId { get; set; }
        public int TShirtId { get; set; }
        public string Color { get; set; }
        public Sizes Size { get; set; }
        public int Quantity { get; set; }
    }
}
