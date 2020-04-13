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
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentsService apartmentsService;

        public ApartmentsController(IApartmentsService apartmentsService)
        {
            this.apartmentsService = apartmentsService;
        }

        // GET: api/Accommodations
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Get([FromQuery]Sieve.Models.SieveModel sieveModel)
        {
            var query = new SieveQuery(sieveModel);
            return Ok(await apartmentsService.GetAll(query));
        }

        // GET: api/Accommodations/5
        [HttpGet("{apartmentId:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get([FromRoute] Guid apartmentId)
        {
            var query = new GetSpecifiedApartmentQuery(apartmentId);
            var result = await apartmentsService.GetDetailedById(query);

            return result.IsFailure
                ? (IActionResult) BadRequest(Result.Failure(result.Error))
                : Ok(result.Value);
        }

        // POST: api/Accommodations
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateApartment([FromBody] CreateApartmentModel createApartmentModel)

        {
            var command = new CreateApartmentCommand(
                createApartmentModel.Title,
                createApartmentModel.Price, 
                createApartmentModel.Area,
                createApartmentModel.NumberOfRooms,
                createApartmentModel.Floor,
                createApartmentModel.TotalNumberOfFloors,
                createApartmentModel.NumberOfBathRooms,
                createApartmentModel.LocationId,
                createApartmentModel.ExactAdress,
                createApartmentModel.Description,
                createApartmentModel.Confort,
                createApartmentModel.ConstructionYear,
                createApartmentModel.ImagesBytes);

            var result = await apartmentsService.Create(command);

            return result.IsFailure
                ? (IActionResult) BadRequest(result.Error)
                : CreatedAtAction(null, "Created Apartment!");
        }

        // PUT: api/Accommodations/5
        [HttpPut("{apartmentId:Guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> UpdateApartment([FromRoute] Guid apartmentId, [FromBody] UpdateApartmentModel updateApartmentModel)
        {
            var command = new UpdateApartmentCommand(apartmentId, updateApartmentModel.Title);
            var result = await apartmentsService.UpdateApartment(command);

            return result.IsFailure
                ? (IActionResult) BadRequest(Result.Failure(result.Error))
                : NoContent();
        }

        //DELETE: api/ApiWithActions/5
        [HttpDelete("{apartmentId:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete([FromRoute] Guid apartmentId)
        {
            var command = new DeleteApartmentByIdCommand(apartmentId);
            var result = await apartmentsService.DeleteById(command);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok();
        }
    }
}
