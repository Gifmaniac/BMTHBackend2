using BusinessLayer.Interfaces.Store.Common;
using BusinessLayer.Interfaces.Store.TShirts;
using BusinessLayer.Mapper.ApiMapper.StoreItems.Common;
using BusinessLayer.Mapper.ApiMapper.StoreItems.Product;
using Contracts.DTOs.StoreItems.Common;
using Contracts.DTOs.StoreItems.Product;
using Microsoft.AspNetCore.Mvc;

namespace BMTH_Application__back_end.Controllers.Store
{
    [ApiController]

    [Route("/api/store/apparel")]
    public class ProductController : ControllerBase
    {
        private readonly ITShirtService _tShirtService;
        private readonly IImageService _imageService;

        public ProductController(ITShirtService service, IImageService imageService)
        {
            _tShirtService = service;
            _imageService = imageService;
        }



        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StoreItemOverviewDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTShirtsOverviewResponse([FromQuery] string genders)
        {
            var overviewDomains = _tShirtService.GetTShirtsByGender(genders);

            if (overviewDomains.Count == 0)
            {
                return NotFound();
            }

            var overviewDtos = StoreItemOverviewApiMapper.ToOverViewDtoList(overviewDomains, _imageService);
            return Ok(overviewDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<ProductDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTShirtByIdResponse(int id)
        {
            var shirt = _tShirtService.GetShirtById(id);

            if (shirt == null)
            {
                return NotFound();
            }

            var dto = ProductsApiMapper.ToDetailsDto(shirt, _imageService);
            return Ok(dto);
        }
    }

}
