using BusinessLayer.Interfaces.Store.Orders;
using Contracts.DTOs.StoreItems.Orders;
using Microsoft.AspNetCore.Mvc;

namespace BMTH_Application_back_end_.Controllers.Store
{
    [ApiController]
    [Route("/api/orders")]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;


        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PostOrderDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostUserOrder([FromBody] PostOrderDto request)
        {
            // Validate required argument
            ArgumentNullException.ThrowIfNull(request);

            if (request.Items == null || request.Items.Count == 0)
                return BadRequest("An order cannot be empty.");

            // Let your service throw exceptions -> your ExceptionMiddleware handles them
            var orderId = _orderService.PostUserOrder(request);

            return Ok(new { orderId });
        }
    }
}
