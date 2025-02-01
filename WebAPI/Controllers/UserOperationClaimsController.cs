using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : Controller
    {
       private IUserOperationClaimService _userOperationClaimService;

        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService)
        {
                _userOperationClaimService = userOperationClaimService;
        }


        [HttpPost("add")]
        public ActionResult Add(UserOperationClaim userOperationClaim)
        {
            
            var result = _userOperationClaimService.Add(userOperationClaim);

            if (result.Success)
            {
                return Ok(result);  
            }

            return BadRequest(result);


        }
    }
}
