using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitiReservation.Controllers;
using UnitiReservation.Core.Models;
using UnitiReservation.Core.Services.ReservationService;
using UnitiReservation.Core.Services.UnitService;

namespace UnitiReservation.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class ReservationController : ControllerBase
    {
        private readonly ILogger<UnitController> _logger;
        private readonly IReservationService _reservationService;

        public ReservationController(ILogger<UnitController> logger, IReservationService reservationService)
        {
            _logger = logger;
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IEnumerable<Reservation>> Index()
        {
            return await _reservationService.GetAllReservations();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Reservation reservation)
        {
            try
            {
                await _reservationService.InsertReservation(reservation);
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
