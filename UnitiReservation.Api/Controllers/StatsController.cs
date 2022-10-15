using Microsoft.AspNetCore.Mvc;
using UnitiReservation.Controllers;
using UnitiReservation.Core.Models.CustomModels.Stats;
using UnitiReservation.Core.Services.ActionsFilters;
using UnitiReservation.Core.Services.StatistiqueService;
using UnitiReservation.Core.Services.UnitService;

namespace UnitiReservation.Api.Controllers
{
    [ApiController]
    [Route("Stats/[Action]")]
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
        [ServiceFilter(typeof(IsValidApiTokenService))]
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
        [ServiceFilter(typeof(IsValidApiTokenService))]
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
