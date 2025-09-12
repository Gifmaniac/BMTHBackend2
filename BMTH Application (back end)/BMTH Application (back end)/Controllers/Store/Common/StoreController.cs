using APIContracts.DTOs.StoreItems.Common;
using Microsoft.AspNetCore.Mvc;
using APIContracts.DTOs.StoreItems.Shirts;
using Contracts.Enums.Store;


namespace BMTH_Application__back_end_.Controllers.Store.Common
{
    [ApiController]
    [Route("store")]


    public class StoreController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStoreCategories([FromQuery] string? gender)
        {
            var categories = new List<StoreCategoryDto>
            {
                new StoreCategoryDto { Category = StoreCategoryType.TShirts, DisplayName = "T-Shirts" },
                new StoreCategoryDto { Category = StoreCategoryType.Hoodies, DisplayName = "Hoodies" },
                new StoreCategoryDto { Category = StoreCategoryType.Jackets, DisplayName = "Jackets" },
                new StoreCategoryDto { Category = StoreCategoryType.Misc, DisplayName = "Miscellaneous" }
            };

            return Ok(categories);
        }
    }
}

