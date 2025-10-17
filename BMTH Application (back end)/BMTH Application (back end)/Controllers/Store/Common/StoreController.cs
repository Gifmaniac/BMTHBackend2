using Microsoft.AspNetCore.Mvc;
using Contracts.Enums.Store;
using Contracts.DTOs.StoreItems.Common;


namespace BMTH_Application__back_end_.Controllers.Store.Common
{
    [ApiController]
    [Route("store")]


    public class StoreController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStoreCategories([FromQuery] string? Category)
        {
            // Parses the genders.
            Genders? parsedCategory = null;

            // Convert the string to Enum, ignores uppercases if success filters on gender
            if (!string.IsNullOrWhiteSpace(Category) && Enum.TryParse<Genders>(Category, true, out var category))
            {
                parsedCategory = category;
            }

            // Makes a invalid check. 
            else
            {
                return NotFound();
            }


            // Get the filtered entities
            // var entities = _tShirtService.GetShirtsByGender(parsedGender);

            // Maps the entities
            // var overview = entities.Select(TShirtApiMapper.ToOverviewDto);

            // return Ok(overview);


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

