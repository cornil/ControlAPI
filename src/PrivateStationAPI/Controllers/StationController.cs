using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PrivateStationAPI.Controllers
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
            var result = await _stationService.GetAll();
            return Ok(result);
        }
    }
}
