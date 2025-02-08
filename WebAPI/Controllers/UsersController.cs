using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService; 
        }

        [HttpGet("getusers")]
        public IActionResult GetUsers()
        {
            var result = _userService.GetUsers();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getusersforcustomer")]
        public IActionResult GetUsersForCustomer()
        {
            var result = _userService.GetUsersForCustomer();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

    }
}
