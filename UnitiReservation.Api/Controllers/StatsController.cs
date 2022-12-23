using Microsoft.AspNetCore.Mvc;
using UnitiReservation.Core.Models.Stats;
using UnitiReservation.Core.Services.Statistics;

namespace UnitiReservation.Api.Controllers
{
    [ApiController]
    [Route("[Controller]/[Action]")]
    public class StatsController : ControllerBase
    {
        private readonly ILogger<UnitsController> _logger;
        private readonly IStatistiqueService _statsService;


        public StatsController(ILogger<UnitsController> logger, IStatistiqueService statsService)
        {
            _logger = logger;
            _statsService = statsService;
        }

        [HttpGet]
        public async Task<IActionResult> TotalVacation()
        {
            return Ok(await _statsService.GetPourcentageVacation());
        }

        [HttpGet]
        public TotalAvailablePerStatus TotalAvailablePerUnitStatus()
        {
            return _statsService.TotalAvailablePerUnitStatus();
        }
    }
}
