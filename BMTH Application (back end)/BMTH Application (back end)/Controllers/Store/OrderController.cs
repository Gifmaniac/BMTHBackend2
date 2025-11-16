using BusinessLayer.Interfaces.Store.Orders;
using BusinessLayer.Services.Store.Orders;
using Contracts.DTOs.StoreItems.Orders;
using Microsoft.AspNetCore.Mvc;

namespace BMTH_Application__back_end_.Controllers.Store
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
            if (request.Items.Count == 0)
            {
                return BadRequest("A order cannot be empty.");
            }

            if (request.UserId == 0)
            {
                request.UserId = 1;
            }

            try
            {
                
                var result = _orderService.PostUserOrder(request);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
