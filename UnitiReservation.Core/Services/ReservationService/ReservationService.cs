using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Infrastructures;
using UnitiReservation.Core.Models;

namespace UnitiReservation.Core.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationDbContext _DbContext;
        public ReservationService(IReservationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _DbContext.Reservations.Find(x => true).ToListAsync();
        }

        public async Task InsertReservation(Reservation reservation)
        {
            await _DbContext.Reservations.InsertOneAsync(reservation);
        }

        public async Task InsertReservation(Unit unit, Reservation reservation)
        {
            reservation.UnitId = unit.Id ?? throw new InvalidDataException("Aucun id");

            await _DbContext.Reservations.InsertOneAsync(reservation);
        }
    }
}
