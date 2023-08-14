using Application.Requests;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Filters;
using Presentation.Requests;
using System.Net;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [VerifyModelBidingActionFilter]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await _userService.LoginAsync(request);
            
            return response.StatusCode == HttpStatusCode.OK ?
                Ok(response.Data) : NotFound(response.ErrorMessage);
        }

        [HttpPost("register")]
        [VerifyModelBidingActionFilter]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _userService.RegisterAsync(request);
            return result.AsT1 == HttpStatusCode.OK ? Ok() : BadRequest();
        }
    }
}
