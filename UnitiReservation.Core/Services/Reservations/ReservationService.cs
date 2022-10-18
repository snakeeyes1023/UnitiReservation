using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Infrastructures.Data.DbContext;
using UnitiReservation.Core.Infrastructures.Data.Entities;

namespace UnitiReservation.Core.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationDbContext _DbContext;
        public ReservationService(IReservationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task InsertReservation(string id, ReservationEntity reservation)
        {
            var filter = Builders<UnitEntity>.Filter.Eq(x => x.Id, id);

            var update = Builders<UnitEntity>.Update
                .AddToSet(x => x.Reservations, reservation);

            await _DbContext.Units.UpdateOneAsync(filter, update);
        }
    }
}
