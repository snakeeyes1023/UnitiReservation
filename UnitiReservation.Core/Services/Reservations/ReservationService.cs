using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Infrastructures.Data.DbContext;
using UnitiReservation.Core.Infrastructures.Data.Entities;
using UnitiReservation.Core.Models.Reservation;

namespace UnitiReservation.Core.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationDbContext _DbContext;
        public ReservationService(IReservationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task InsertReservation(string id, ReservationModel reservation)
        {
            UnitEntity unit = await _DbContext.Units.Find(x => x.Id == id).FirstOrDefaultAsync();

            if (unit != null)
            {
                var filter = Builders<UnitEntity>.Filter.Eq(x => x.Id, id);

                var reservationEntity = new ReservationEntity
                {
                    StartDate = reservation.FromDate,
                    EndDate = reservation.ToDate,
                    Price = unit.DisplayPricing,
                };

                var update = Builders<UnitEntity>.Update
                    .AddToSet(x => x.Reservations, reservationEntity);

                await _DbContext.Units.UpdateOneAsync(filter, update);
            }
            else
            {
                throw new InvalidOperationException("Unité non trouvée");
            }
        }
    }
}
