using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using YourApartment.Business;

namespace YourApartment.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AccommodationsController : ControllerBase
    {
        private readonly IServiceAccommodations accommodationsService;

        public AccommodationsController(IServiceAccommodations accommodationsService)
        {
            this.accommodationsService = accommodationsService;
        }

        // GET: api/Accommodations
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Get([FromQuery]Sieve.Models.SieveModel sieveModel)
        {
            var query = new SieveQuery(sieveModel);
            return Ok(await accommodationsService.GetAll(query));
        }

        // GET: api/Accommodations/5
        [HttpGet("{accommodationId:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get([FromRoute] Guid accommodationId)
        {
            var query = new GetSpecifiedAccommodationQuery(accommodationId);

            var result = await accommodationsService.GetSpecifiedAccommodation(query);

            return result.IsFailure
                ? (IActionResult) BadRequest(Result.Failure(result.Error))
                : Ok(result.Value);
        }

        // POST: api/Accommodations
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAccommodation([FromBody] CreateAccommodationModel createAccommodationModel)
        {
            var command = new CreateAccommodationCommand(createAccommodationModel.Title);
            var result = await accommodationsService.Create(command);
            
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(null,"Created!");
        }

        // PUT: api/Accommodations/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        //DELETE: api/ApiWithActions/5
        [HttpDelete("{accommodationId:Guid}/messages")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete([FromRoute] Guid accommodationId)
        {
            var command = new DeleteAccommodationByIdCommand(accommodationId);
            var result = await accommodationsService.DeleteById(command);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok();
        }
    }
}
