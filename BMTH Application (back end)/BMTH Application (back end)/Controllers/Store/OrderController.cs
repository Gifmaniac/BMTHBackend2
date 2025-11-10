using BusinessLayer.Services.Store.Orders;
using Contracts.DTOs.StoreItems.Orders;
using Microsoft.AspNetCore.Mvc;

namespace BMTH_Application__back_end_.Controllers.Store
{
    [ApiController]
    [Route("/api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            orderService = _orderService;
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<CreatedOrdersDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostUserOrder([FromBody] CreatedOrdersDto request)
        {
            if (request.Orders.Count == 0)
            {
                return BadRequest("Orders cannot be empty.");
            }

            if (request.UserId == 0)
            {
                request.UserId = 1;
            }
            if (string.IsNullOrWhiteSpace(request.Status))
            {
                request.Status = "Created";
            }

            try
            {
                var result = _orderService.PostUserOrder(request.OrderId);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
