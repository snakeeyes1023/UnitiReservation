using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitiReservation.Controllers;
using UnitiReservation.Core.Models.Entities;
using UnitiReservation.Core.Services.ReservationService;
using UnitiReservation.Core.Services.UnitService;

namespace UnitiReservation.Api.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class ReservationsController : ControllerBase
    {
        private readonly ILogger<UnitsController> _logger;
        private readonly IReservationService _reservationService;

        public ReservationsController(ILogger<UnitsController> logger, IReservationService reservationService)
        {
            _logger = logger;
            _reservationService = reservationService;
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> Post([FromRoute] string id, [FromBody] Reservation reservation)
        {
            try
            {
                await _reservationService.InsertReservation(id, reservation);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Erreur d'insertion d'une réservation", ex);

                return BadRequest("Impossible de créer la réservation");
            }
        }
    }
}
