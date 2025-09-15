using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Enums.Store;

namespace DataLayer.Entities
{
    public class TShirtVariantEntity
    {
        public int Id { get; set; }
        public int TShirtId { get; set; }
        public string Color { get; set; }
        public Sizes Size { get; set; }
        public int Quantity { get; set; }
    }
}
