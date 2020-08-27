using Microsoft.AspNetCore.Mvc;
using Models;
using Service;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteService _rouletteService;
        public RouletteController(IRouletteService rouletteService)
        {
            _rouletteService = rouletteService;
        }

        [HttpPost]
        [Route("CreateRoulette")]
        public IActionResult CreateRoulette([FromBody] RouletteCreatePayload payload)
        {
            var responsePackage = _rouletteService.CreateRoulette(payload);
            return Ok(responsePackage);
        }

        [HttpPost]
        [Route("OpenRoulette")]
        public IActionResult OpenRoulette([FromBody] RouletteOpenPayload payload)
        {
            var responsePackage = _rouletteService.OpenRoulette(payload);
            return Ok(responsePackage);
        }

        [HttpPost]
        [Route("CreateRouletteBet")]
        public IActionResult CreateRouletteBet([FromBody] RouletteBetPayload payload)
        {
            var responsePackage = _rouletteService.CreateRouletteBet(payload);
            return Ok(responsePackage);
        }
        [HttpPost]
        [Route("CloseRoulette")]
        public IActionResult CloseRoulette([FromBody] RouletteClosePayload payload)
        {
            var responsePackage = _rouletteService.CloseRoulette(payload);
            return Ok(responsePackage);
        }



        [HttpGet]
        [Route("GetRoulettes")]
        public IActionResult GetRoulettes()
        {

            var responsePackage = _rouletteService.GetRoulettes();
            return Ok(responsePackage);
        }
    }
}
