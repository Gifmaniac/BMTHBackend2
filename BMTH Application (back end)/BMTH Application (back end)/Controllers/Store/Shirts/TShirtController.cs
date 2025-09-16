using System.Diagnostics.Eventing.Reader;
using APIContracts.DTOs.StoreItems.Common;
using APIContracts.DTOs.StoreItems.Shirts;
using BMTH_Application__back_end_.Mappers.StoreItems.TShirts;
using BusinessLayer.Mappers.Store;
using BusinessLayer.Services;
using Contracts.Enums.Store;
using Microsoft.AspNetCore.Mvc;

namespace BMTH_Application__back_end_.Controllers.Store.Shirts
{
    [ApiController]

    [Route("store/tshirts")]
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
            // Parses the genders.
            Genders? parsedGender = null;

            // Convert the string to Enum, ignores uppercases if success filters on gender
            if (!string.IsNullOrWhiteSpace(genders) && Enum.TryParse<Genders>(genders, true, out var gender))
            {
                parsedGender = gender;
            }

            // Makes a invalid check. 
            else
            {
                return NotFound();
            }
            

            // Get the filtered entities
            var entities = _tShirtService.GetAllTShirts(parsedGender);

            // Maps the entities
            var overview = entities.Select(TShirtApiMapper.ToOverviewDto);

            return Ok(overview);
        }

        [HttpGet("{id}")]
        public IActionResult GetTShirtByIdResponse(int id)
        {
            var entities = _tShirtService.GetAllTShirts();
            var shirt = entities.FirstOrDefault(s => s.Id == id);

            if (shirt == null)
                return NotFound();

            var dto = TShirtMapper.ToDto(shirt);
            return Ok(dto);
        }
    }
}
