using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Infrastructures;
using UnitiReservation.Core.Models.Entities;

namespace UnitiReservation.Core.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationDbContext _DbContext;
        public ReservationService(IReservationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task InsertReservation(string id, Reservation reservation)
        {
            var filter = Builders<Unit>.Filter.Eq(x => x.Id, id);

            var update = Builders<Unit>.Update
                .AddToSet(x => x.Reservations, reservation);

            await _DbContext.Units.UpdateOneAsync(filter, update);
        }
    }
}
