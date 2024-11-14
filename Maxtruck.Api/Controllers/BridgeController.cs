using Maxtruck.Application.Dtos;
using Maxtruck.Application.Interfaces;
using Maxtruck.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Maxtruck.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BridgeController : ControllerBase
    {
        private readonly IBridgeService _bridgeService;

        public BridgeController(IBridgeService bridgeService)
        {
            _bridgeService = bridgeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BridgeDto>>> GetBridgesAsync()
        {
            return await _bridgeService.GetBridgesAsync();
        }

        [HttpPost]
        public async Task<ActionResult> CreateBridgeAsync(BridgeDto input)
        {
            await _bridgeService.AddBridgeAsync(input);
            return Ok("bridge created successfuly");
        }
    }
}
