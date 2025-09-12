using Contracts.Enums.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIContracts.DTOs.StoreItems.Common
{
    public class StoreCategoryDto
    {
        public StoreCategoryType Category { get; set; }        // For the API Routing
        public string DisplayName { get; set; }     
    }
}
