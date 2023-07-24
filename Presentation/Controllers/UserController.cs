using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Filters;
using Presentation.Requests;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        [HttpPost("login")]
        [VerifyModelBidingActionFilter]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            return Ok();
        }

        [HttpPost("register")]
        [VerifyModelBidingActionFilter]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
                     
            return Ok();
        }
    }
}
