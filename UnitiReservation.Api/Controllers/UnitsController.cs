using Microsoft.AspNetCore.Mvc;
using UnitiReservation.Core.Infrastructures.Data.Entities;
using UnitiReservation.Core.Services.Units;

namespace UnitiReservation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitsController : ControllerBase
    {

        private readonly ILogger<UnitsController> _logger;
        private readonly IUnitService _unitService;

        public UnitsController(ILogger<UnitsController> logger, IUnitService unitService)
        {
            _logger = logger;
            _unitService = unitService;
        }

        #region GET

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitService.GetAllUnits());
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            UnitEntity unitEntity = await _unitService.GetById(id);

            if (unitEntity == null)
            {
                return NotFound();
            }

            return Ok(unitEntity);
        }

        [HttpGet]
        [Route("{from}/{to}")]
        public async Task<IActionResult> Get([FromRoute] decimal from, [FromRoute] decimal to)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _unitService.GetBetween(from, to));
            }
            return BadRequest(ModelState);
        }

        #endregion

        #region POST

        [HttpPost]
        public async Task<IActionResult> Post(UnitEntity unit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok(await _unitService.InsertUnit(unit));
                }
                catch (Exception)
                {
                    return BadRequest("Impossible d'insérer l'unité");
                }
            }
            return BadRequest(ModelState);
        }

        #endregion

        #region PUT

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] UnitEntity unit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    unit.Id = id;
                    
                    return Ok(await _unitService.UpdateUnit(unit));
                }
                catch (Exception ex)
                {
                    return BadRequest("Impossible de modifier l'unité");
                }
            }
            return BadRequest(ModelState);
        }

        #endregion

        #region DELETE

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitService.Delete(id);

                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest("Impossible de supprimer l'unité");
                }
            }
            return BadRequest(ModelState);
        }

        #endregion
    }
}