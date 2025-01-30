using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet("getreports")]
        public IActionResult GetInventoryReports()
        {
            var result = _orderService.GetOrderReports();   

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
