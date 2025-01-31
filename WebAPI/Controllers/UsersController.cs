using Business.Abstract;
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
    }
}
