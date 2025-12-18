using BusinessLayer.Interfaces.Store;
using BusinessLayer.Interfaces.Store.Common;
using BusinessLayer.Mapper.ApiMapper.StoreItems.Common;
using BusinessLayer.Mapper.ApiMapper.StoreItems.Product;
using Contracts.DTOs.StoreItems.Common;
using Contracts.DTOs.StoreItems.Product;
using Contracts.Enums.Store;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BMTH_Application__back_end_.Controllers.Store
{
    [ApiController]

    [Route("api/store/apparel")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IImageService _imageService;

        public ProductController(IProductService service, IImageService imageService)
        {
            _productService = service;
            _imageService = imageService;
        }



        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StoreItemOverviewDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProductOverviewResponse([FromQuery] string genders)
        {
            if (!Enum.TryParse<Genders>(genders, true, out var genderEnum))
            {
                return BadRequest($"Invalid gender value: {genders}");
            }

            var overviewDomains = _productService.GetProductByGender(genderEnum);

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
        public IActionResult GetProductByIdResponse(int id)
        {

            var productById = _productService.GetProductById(id);

            if (productById == null)
            {
                return NotFound();
            }

            var dto = ProductsApiMapper.ToDetailsDto(productById, _imageService);
            return Ok(dto);
        }

        [HttpPatch("{productId}/{variantId}/{amount}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<StoreItemOverviewDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult UpdateProductStockById(int productId, int variantId, int amount)
        {
            var product = _productService.UpdateStock(productId, variantId, amount);

            if (product == null)
            {
                return NotFound();
            }

            var dto = ProductsApiMapper.ToDetailsDto(product, _imageService);

            return Ok(dto);
        }

        [HttpDelete("{productId}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult DeleteProduct(int productId)
        {
            _productService.DeleteProduct(productId);
            return NoContent();
        }

        [HttpDelete("{productId}/{variantId}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult DeleteProductVariant(int productId, int variantId)
        {
            _productService.DeleteVariants(productId, variantId);
            return NoContent();
        }
    }
}
