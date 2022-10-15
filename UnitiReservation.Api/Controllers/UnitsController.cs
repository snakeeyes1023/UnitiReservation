using Microsoft.AspNetCore.Mvc;
using UnitiReservation.Core.Models.Entities;
using UnitiReservation.Core.Services.UnitService;

namespace UnitiReservation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitsController : ControllerBase
    {

        private readonly ILogger<UnitsController> _logger;
        private readonly IUnitServices _unitService;

        public UnitsController(ILogger<UnitsController> logger, IUnitServices unitService)
        {
            _logger = logger;
            _unitService = unitService;
        }

        #region GET

        [HttpGet]
        public async Task<IEnumerable<Unit>> Get()
        {
            try
            {
                return await _unitService.GetAllUnits();
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<Unit> Get([FromRoute] string id)
        {
            try
            {
                return await _unitService.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("{from}/{to}")]
        public async Task<IEnumerable<Unit>> Get([FromRoute] decimal from, [FromRoute] decimal to)
        {
            try
            {
                return await _unitService.GetBetween(from, to);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region POST

        [HttpPost]
        public async Task<IActionResult> Post(Unit unit)
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

        #endregion

        #region PUT

        [HttpPut]
        public async Task<IActionResult> Put(Unit unit)
        {
            try
            {
                await _unitService.UpdateUnit(unit);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Impossible de modifier l'unité");
            }
        }

        #endregion

        #region DELETE

        [HttpDelete]
        public async Task<IActionResult> Delete(Unit unit)
        {
            try
            {
                await _unitService.Delete(unit);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Impossible de supprimer l'unité");
            }
        }

        #endregion
    }
}