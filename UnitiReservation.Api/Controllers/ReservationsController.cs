using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitiReservation.Controllers;
using UnitiReservation.Core.Infrastructures.Data.Entities;
using UnitiReservation.Core.Services.Reservations;

namespace UnitiReservation.Api.Controllers
{
    [ApiController]
    [Authorize]
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
        public async Task<IActionResult> Post([FromRoute] string id, [FromBody] ReservationEntity reservation)
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
