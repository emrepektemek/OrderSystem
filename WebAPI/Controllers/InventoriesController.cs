using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController : Controller
    {
        IInventoryService _inventoryService;

        public InventoriesController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet("getreports")]
        public IActionResult GetInventoryReports()
        {
            var result = _inventoryService.GetInventoryReports();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

    }
}
