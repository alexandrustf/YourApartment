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
    [Route("api/[controller]")]
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
        public IEnumerable<AccommodationModel> Get()
        {
            var command = new GetAccommodationsQuery();
            var result = accommodationsService.GetAll(command).Result;
            return result;
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

            return Ok();
        }

        // PUT: api/Accommodations/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
