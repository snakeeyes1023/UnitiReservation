using Microsoft.AspNetCore.Mvc;
using UnitiReservation.Core.Models;
using UnitiReservation.Core.Services.UnitService;

namespace UnitiReservation.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class UnitController : ControllerBase
    {

        private readonly ILogger<UnitController> _logger;
        private readonly IUnitServices _unitService;

        public UnitController(ILogger<UnitController> logger, IUnitServices unitService)
        {
            _logger = logger;
            _unitService = unitService;
        }

        [HttpGet]
        public async Task<IEnumerable<Unit>> Index()
        {
            return await _unitService.GetAllUnits();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Unit unit)
        {
            try
            {
                await _unitService.InsertUnit(unit);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Impossible d'insérer l'unité");
            }
        }


        [HttpGet]
        public async Task<IEnumerable<Unit>> Free()
        {
            return await _unitService.GetFreeUnit();
        }
    }
}