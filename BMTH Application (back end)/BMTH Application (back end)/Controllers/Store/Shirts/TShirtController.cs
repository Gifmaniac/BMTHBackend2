using BusinessLayer.Mapper.ApiMapper.StoreItems.TShirts;
using BusinessLayer.Services;
using Contracts.Enums.Store;
using Microsoft.AspNetCore.Mvc;

namespace BMTH_Application__back_end_.Controllers.Store.Shirts
{
    [ApiController]

    [Route("/api/store/apparel")]
    public class TShirtController : ControllerBase
    {
        private readonly TShirtService _tShirtService;

        public TShirtController(TShirtService service)
        {
            _tShirtService = service;
        }


        [HttpGet]
        public IActionResult GetTShirtsResponse([FromQuery] string? gender)
        {

            if (string.IsNullOrEmpty(gender) || !Enum.TryParse<Genders>(gender, true, out var parsedGender))
            {
                return BadRequest("Invalid request");
            }

            var domainModels = _tShirtService.GetTShirtsByGender(parsedGender);

            var dtoList = domainModels.Select(TShirtApiMapper.ToDetailsDto).ToList();

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public IActionResult GetTShirtByIdResponse(int id)
        { 
            var shirts = _tShirtService.GetTShirtsByGender();

            var shirt = shirts.FirstOrDefault(s => s.Id == id);

            if (shirt == null)
            {
                return NotFound();
            }

            var dto = TShirtApiMapper.ToDetailsDto(shirt);

            return Ok(dto);
        }
    }
}
