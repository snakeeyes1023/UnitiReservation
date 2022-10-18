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
        public AveragePriceByAvailable AveragePricePerUnitStatus([FromQuery] string apiKey)
        {
            try
            {
                return _statsService.AveragePricePerUnitStatus();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public TotalAvailablePerStatus TotalAvailablePerUnitStatus([FromQuery] string apiKey)
        {
            try
            {
                return _statsService.TotalAvailablePerUnitStatus();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
