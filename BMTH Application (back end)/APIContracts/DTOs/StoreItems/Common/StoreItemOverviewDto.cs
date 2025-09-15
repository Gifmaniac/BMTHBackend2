using Contracts.Enums.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIContracts.DTOs.StoreItems.Common
{
    public class StoreItemOverviewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public StoreCategoryType Category { get; set; }
        public Genders Gender { get; set; }
    }
}
