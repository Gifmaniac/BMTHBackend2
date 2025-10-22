using Contracts.Enums.Store;

namespace Contracts.DTOs.StoreItems.Common
{
    public class StoreCategoryDto
    {
        public StoreCategoryType Category { get; set; }        // For the API Routing
        public string DisplayName { get; set; } = string.Empty;
    }
}
