using Microsoft.AspNetCore.Mvc;
using Contracts.Enums.Store;
using Contracts.DTOs.StoreItems.Common;


namespace BMTH_Application_back_end_.Controllers.Store.Common
{
    [ApiController]
    [Route("store")]


    public class StoreController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StoreCategoryType>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetStoreCategories([FromQuery] string? Category)
        {
            // TODO: Implement category filtering once front end is ready

            if (string.IsNullOrWhiteSpace(Category) && !Enum.TryParse<Genders>(Category, true, out var parsedCategory))
            {
                return NotFound();
            }

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

