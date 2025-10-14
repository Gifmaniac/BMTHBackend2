using
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
        public IActionResult GetTShirtsResponse([FromQuery] string? genders)
        {
            if (!Enum.TryParse(genders, true, out Genders gender))
            {
                return BadRequest("Invalid gender value.");
            }

            var overviewDtos = _tShirtService.GetShirtsByGender(gender);
            return Ok(overviewDtos);

            //// Parses the genders.
            //Genders? parsedGender = null;

            //// Convert the string to Enum, ignores uppercases if success filters on gender
            //if (!string.IsNullOrWhiteSpace(genders) && Enum.TryParse<Genders>(genders, true, out var gender))
            //{
            //    parsedGender = gender;
            //}

            //// Makes an invalid check. 
            //else
            //{
            //    return NotFound();
            //}
            

            //// Get the filtered entities
            //var entities = _tShirtService.GetShirtsByGender(parsedGender);

            //// Maps the entities
            //var overview = entities.Select(TShirtApiMapper.ToOverviewDto);

            return Ok(overview);
        }

        [HttpGet("{id}")]
        public IActionResult GetTShirtByIdResponse(int id)
        {
            var shirts = _tShirtService.GetShirtsByGender();
            var shirt = shirts.FirstOrDefault(s => s.Id == id);

            if (shirt == null)
            {
                return NotFound();
            }

            var dto = TShirtApiMapper.ToDetailDto(shirt);
            return Ok(dto);
        }
    }
}
