using APIContracts.DTOs.StoreItems.Common;
using APIContracts.DTOs.StoreItems.Shirts;
using Contracts.Enums.Store;
using Microsoft.AspNetCore.Mvc;

namespace BMTH_Application__back_end_.Controllers.Store.Shirts
{
    [ApiController]

    [Route("store/tshirts")]
    public class TShirtController : ControllerBase
    {
        private static readonly List<TShirtDetailsDto> _tShirts = new()
        {
            new TShirtDetailsDto(1, "Limited Edition Tee", 29.99m, 30)
            {
                Variants = new List<TShirtVariantDto>
                {
                    new TShirtVariantDto { Color = "Black", Size = Sizes.S, Quantity = 5 },
                    new TShirtVariantDto { Color = "Black", Size = Sizes.M, Quantity = 8 },
                    new TShirtVariantDto { Color = "White", Size = Sizes.M, Quantity = 10 },
                    new TShirtVariantDto { Color = "White", Size = Sizes.L, Quantity = 7 }
                }
            }
        };


        [HttpGet]
        public IActionResult GetTShirtsResponse([FromQuery] string? gender)
        {
            var overview = _tShirts.Select( s => new StoreItemOverviewDto()
            {
                    Id = s.Id,
                    Name = s.Name,
                    Price = s.Price,
                    Category = s.Category
            });

            return Ok(overview);
        }

        [HttpGet("{id}")]
        public IActionResult GetTShirtByIdResponse(int id)
        {
            var shirt = _tShirts.FirstOrDefault(s => s.Id == id);
            if (shirt == null) 
                return NotFound();

            return Ok(shirt);
        }
    }
}
