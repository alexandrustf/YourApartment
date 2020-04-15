using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourApartment.Business;

namespace YourApartment.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationsService locationsService;

        public LocationsController(ILocationsService locationsService)
        {
            this.locationsService = locationsService;
        }
        // GET: api/Locations
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Get() => Ok(await locationsService.GetAll());

        // GET: api/Locations/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Locations
        [HttpPost]
        [Authorize]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] CreateLocationModel createLocationModel)
        {
            var command = new CreateLocationCommand(createLocationModel.Name, createLocationModel.PreciseAdress);

            var result = await locationsService.Create(command);

            return result.IsFailure
                ? (IActionResult) BadRequest(result.Error) 
                : CreatedAtAction(null, "Created Location!");
        }

        // PUT: api/Locations/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // DELETE: api/ApiWithActions/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
