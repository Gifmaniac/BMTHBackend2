//using BusinessLayer.Mapper.ApiMapper.StoreItems.Common;
//using Contracts.DTOs.StoreItems.Orders;
//using Microsoft.AspNetCore.Mvc;

//namespace BMTH_Application__back_end_.Controllers.Store
//{
//    public class OrderController
//    {
//        [HttpPost]
//        [ProducesResponseType(typeof(IEnumerable<CreatedOrdersDto>), StatusCodes.Status200OK)]
//        public IActionResult PostUserOrder([FromQuery] string genders)
//        {
//            var overviewDomains = _tShirtService.GetTShirtsByGender(genders);

//            if (overviewDomains.Count == 0)
//            {
//                return NotFound();
//            }

//            var overviewDtos = StoreItemOverviewApiMapper.ToOverViewDtoList(overviewDomains, _imageService);
//            return Ok(overviewDtos);
//        }
//    }
//}
