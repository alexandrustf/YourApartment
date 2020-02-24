using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAll()
        {
            var command = new GetAccommodationsQuery();
            return Ok(await accommodationsService.GetAll(command));
        }

        // GET: api/Accommodations/5
        [HttpGet("{accommodationId:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAccommodationById([FromRoute] Guid accommodationId)
        {
            var query = new GetAccommodationById(accommodationId);
            var result = await accommodationsService.GetById(query);

            return result.HasValue
                ? Ok(result.Value)
                : (IActionResult)NotFound();
        }

        // POST: api/Accommodations
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddAccommodation([FromBody] CreateAccommodationModel createAccommodationModel)
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{accommodationId:Guid}/messages")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete([FromRoute] Guid accommodationId)
        {
            var command = new DeleteAccommodationByIdCommand(accommodationId);
            var result = await accommodationsService.DeleteById(command);

            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok();
        }
    }
}
