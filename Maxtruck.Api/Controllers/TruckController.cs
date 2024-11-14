using Maxtruck.Application.Dtos;
using Maxtruck.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Maxtruck.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        private readonly ITruckService _truckService;

        public TruckController(ITruckService truckService)
        {
            _truckService = truckService;
        }

        [HttpGet]   
        public async Task<ActionResult<List<TruckDto>>> GetTrucksAsync()
        {
            return await _truckService.GetTrucksAsync();
        }

        [HttpPost]
        public async Task<ActionResult> CreateTruckAsync([FromBody]TruckDto truck)
        {
            await _truckService.AddTruckAsync(truck);
            return Ok("truck created successfuly");
        }
    }
}
