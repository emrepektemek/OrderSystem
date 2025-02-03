using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {

        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService; 
                
        }


        [HttpPost("add")]
        public ActionResult Add(Customer customer)
        {

            var result = _customerService.Add(customer);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);


        }


        [HttpGet("getall")]
        public IActionResult GetCustomers()
        {
            var result = _customerService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

    }
}
