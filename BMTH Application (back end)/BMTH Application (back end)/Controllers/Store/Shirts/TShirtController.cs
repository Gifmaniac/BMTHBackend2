using BusinessLayer.Interfaces.Store.Common;
using BusinessLayer.Interfaces.Store.TShirts;
using BusinessLayer.Mapper.ApiMapper.StoreItems.Common;
using BusinessLayer.Mapper.ApiMapper.StoreItems.TShirts;
using BusinessLayer.Services.Store.Common;
using Contracts.DTOs.StoreItems.Common;
using Contracts.DTOs.StoreItems.Shirts;
using Microsoft.AspNetCore.Mvc;

namespace BMTH_Application__back_end_.Controllers.Store.Shirts
{
    [ApiController]

    [Route("/api/store/apparel")]
    public class TShirtController : ControllerBase
    {
        private readonly ITShirtService _tShirtService;
        private readonly IImageService _imageService;

        public TShirtController(ITShirtService service, IImageService imageService)
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
        [ProducesResponseType(typeof(IEnumerable<TShirtDetailsDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTShirtByIdResponse(int id)
        { 
            var shirt = _tShirtService.GetShirtById(id);

            if (shirt == null)
            {
                return NotFound();
            }

            var dto = TShirtApiMapper.ToDetailsDto(shirt, _imageService);
            return Ok(dto);
        }
    }

}
