using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using EnsureThat;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourApartment.Business;

namespace YourApartment.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            EnsureArg.IsNotNull(authService);
            this.authService = authService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CheckCredentials([FromBody] CredentialsModel credentialsModel)
        {
            var credentialsCommand = new AuthenticateUserCommand(credentialsModel.Email, credentialsModel.Password);

            var result = await authService.Authenticate(credentialsCommand);

            return result.IsFailure
                ? (IActionResult)BadRequest(Result.Fail(result.Error))
                : Ok(result);
        }
    }
}