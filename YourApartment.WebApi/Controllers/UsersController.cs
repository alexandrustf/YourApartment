using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourApartment.Business;
using YourApartment.Domain;

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
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateModel model)
        {
            var command = new AuthenticateUserCommand(model.Email, model.Password);

            var result = await userService.Authenticate(command);

            return result.IsFailure
                ? (IActionResult)BadRequest(result.Error)
                : Ok(result.Value);
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



        [HttpGet]
        [Authorize(Roles = AppRole.User)]
        [ProducesResponseType(200)]
        public IActionResult GetAll()
        {
            
            return Ok("Numai un user poate accesa asta!");
        }

        [HttpGet("admin")]
        [Authorize(Roles = AppRole.Admin)]
        public IActionResult GetSome()
        {
            return Ok("Doar cei ca admin logati pot accesa asta!");
        }
    }
}