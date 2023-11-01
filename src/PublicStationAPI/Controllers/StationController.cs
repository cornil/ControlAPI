using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PublicStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;

        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _stationService.GetStationAsync());
        }
    }
}
