using System;
using PetCare.Domain.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetCare.Domain.Communication;

namespace PetCare.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
            /* var payments = await _PaymentService.ListByServicesProviderIdAsync(providerId);*/
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest request)
        {
            var response = _userService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = "Invalid Username or Password" });

            return Ok(response);
        }

        

        /*[HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }*/
    }
}


