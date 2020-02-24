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
        public IEnumerable<AccommodationModel> Get()
        {
            var command = new GetAccommodationsQuery();
            var result = accommodationsService.GetAll(command).Result;
            return result;
        }

        // GET: api/Accommodations/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Accommodations
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] CreateAccommodationModel createAccommodationModel)
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
