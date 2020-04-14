using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourApartment.Business;
using YourApartment.Domain;
using YourApartment.WebApi.Models;

namespace YourApartment.WebApi.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateModel model)
        {
            var user = await userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            // map model to entity

            var command = new CreateUserCommand(model.Name, model.Email, model.PhoneNumber, model.Password);

            var result = await userService.Create(command);

            return result.IsFailure
                ? (IActionResult)BadRequest(result.Error)
                : CreatedAtAction(null, "Created User!");
        }



        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = userService.GetAll();
        //    return Ok(users);
        //}
    }
}