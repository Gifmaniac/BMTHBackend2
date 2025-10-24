using APIContracts.DTOs.StoreItems.Common;
using BusinessLayer.Interfaces.Store.TShirts;
using BusinessLayer.Mapper.ApiMapper.StoreItems.Common;
using BusinessLayer.Mapper.ApiMapper.StoreItems.TShirts;
using Contracts.DTOs.StoreItems.Shirts;
using Microsoft.AspNetCore.Mvc;

namespace BMTH_Application__back_end_.Controllers.Store.Shirts
{
    [ApiController]

    [Route("/api/store/apparel")]
    public class TShirtController : ControllerBase
    {
        private readonly ITShirtService _tShirtService;

        public TShirtController(ITShirtService service)
        {
            _tShirtService = service;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StoreItemOverviewDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTShirtsOverviewResponse([FromQuery] string? gender)
        {

            var overviewDomains = _tShirtService.GetTShirtsByGender(gender);

            if (!overviewDomains.Any())
            {
                return NotFound();
            }

            var overviewDtos = StoreItemOverviewApiMapper.ToOverViewDtoList(overviewDomains);
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

            var dto = TShirtApiMapper.ToDetailsDto(shirt);
            return Ok(dto);
        }
    }

}
