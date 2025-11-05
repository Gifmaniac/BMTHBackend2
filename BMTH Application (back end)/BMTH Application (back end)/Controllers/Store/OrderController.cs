using Contracts.DTOs.StoreItems.Orders;
using Microsoft.AspNetCore.Mvc;

namespace BMTH_Application__back_end_.Controllers.Store
{
    [ApiController]
    [Route("/api/orders")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<CreatedOrdersDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostUserOrder([FromBody] CreatedOrdersDto request)
        {
            if (request.Orders.Count == 0)
            {
                return BadRequest("Orders cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(request.Status))
            {
                request.Status = "Created";
            }

            if (request.UserId == 0)
            {
                request.UserId = 1;
            }

            return Ok(request);
        }
    }
}
