using Maxtruck.Application.Dtos;
using Maxtruck.Application.Interfaces;
using Maxtruck.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Maxtruck.Api.Controllers
{
    [Route("api/trucks")]
    [ApiController]
    public class TrucksController : ControllerBase
    {
        private readonly ITruckService _truckService;

        public TrucksController(ITruckService truckService)
        {
            _truckService = truckService;
        }

        [HttpGet]   
        public async Task<ActionResult<List<TruckDto>>> GetTrucksAsync()
        {
            return await _truckService.GetTrucksAsync();
        }

        [HttpGet("user")]
        public async Task<ActionResult<List<Truck>>> GetTrucksByUserIdAsync([FromQuery] Guid userId)
        {
            return await _truckService.GetTrucksByUserIdAsync(userId);
        }

        [HttpGet("{truckId}/details")]
        public async Task<ActionResult<TruckDetails>> GetTruckDetaisAsync([FromRoute] Guid truckId)
        {
           return await _truckService.GetTruckDetailsAsync(truckId);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTruckAsync([FromBody]TruckDto truck)
        {
            await _truckService.AddTruckAsync(truck);
            return Ok("truck created successfuly");
        }
    }
}
