using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
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
            var command = new CreateUserCommand(model.Name, model.Email, model.Phone, model.Password);

            var result = await userService.Create(command);

            return result.IsFailure
                ? (IActionResult)BadRequest(result.Error)
                : CreatedAtAction(null, "Created User!");
        }

        [Authorize]
        [HttpPost("favorite")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddFavorite([FromBody] FavoriteModel favoriteModel)
        {
            var command = new AddToFavoriteCommand(favoriteModel.IdApartment, HttpContext.ExtractEmail());

            var result = await userService.AddFavoriteApartment(command);

            return result.IsFailure
                ? (IActionResult)BadRequest(result.Error)
                : CreatedAtAction(null, "Added favorite apartment to user!");
        }



        [HttpGet("favorite")]
        [Authorize(Roles = AppRole.User)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAll()
        {
            var command = new GetFavoriteApartmentsForUserQuery(HttpContext.ExtractEmail());

            var result = await userService.getFavoriteApartments(command);

            return result.IsFailure
                ? (IActionResult)BadRequest(Result.Failure(result.Error))
                : Ok(result.Value);
        }
    }
}