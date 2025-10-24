using BusinessLayer.Interfaces.Store.TShirts;
using BusinessLayer.Mapper.ApiMapper.StoreItems.Common;
using BusinessLayer.Mapper.ApiMapper.StoreItems.TShirts;
using BusinessLayer.Services;
using DataLayer.Models.Store.TShirts;
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
        public IActionResult GetTShirtsOverviewResponse([FromQuery] string? gender)
        {
            var overviewDomains = _tShirtService.GetTShirtsByGender(gender);
            var overviewDtos = StoreItemOverviewApiMapper.ToOverViewDtoList(overviewDomains);
            return Ok(overviewDtos);
        }

        [HttpGet("{id}")]
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
