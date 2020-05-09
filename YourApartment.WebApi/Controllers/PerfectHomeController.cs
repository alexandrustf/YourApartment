using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourApartment.Business;
using YourApartment.WebApi.Models;

namespace YourApartment.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PerfectHomeController : ControllerBase
    {
        private readonly IPerfectHomeService perfectHomeService;


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostPerfectHome([FromBody] PerfectHomeModel perfectHomeModel)
        {
            var command = new PerfectHomeQuery(perfectHomeModel.FavoriteLocations, 
                perfectHomeModel.NearMall, perfectHomeModel.NearHospital, 
                perfectHomeModel.MaxPrice);

            var result = await perfectHomeService.PerfectApartments(command);

            return result.IsFailure
                ? (IActionResult)BadRequest(result.Error)
                : Ok(result.Value);
        }

    }
}
