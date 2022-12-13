using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitiReservation.Core.Infrastructures.Data.Entities;
using UnitiReservation.Core.Models.Reservation;
using UnitiReservation.Core.Services.Reservations;

namespace UnitiReservation.Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public async Task<IActionResult> Post([FromRoute] string id, [FromBody] ReservationModel reservation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _reservationService.InsertReservation(id, reservation);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest("Impossible de créer la réservation");
                }
            }

            return BadRequest(ModelState);
        }
    }
}
