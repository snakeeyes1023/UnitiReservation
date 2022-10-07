using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UnitiReservation.Core.Infrastructures.Settings;
using UnitiReservation.Core.Models;

namespace UnitiReservation.Core.Infrastructures
{
    public class ReservationDbContext : IReservationDbContext
    {
        private readonly Lazy<IMongoCollection<Reservation>> _Reservations;
        public IMongoCollection<Reservation> Reservations { get { return _Reservations.Value; } }


        private readonly Lazy<IMongoCollection<Unit>> _Units;
        public IMongoCollection<Unit> Units { get { return _Units.Value; } }


        private IMongoClient Client;
        private IMongoDatabase Database;


        public ReservationDbContext(IOptions<UnitiReservationDatabaseSettings> reservationDbContext)
        {
            Client = new MongoClient(reservationDbContext.Value.ConnectionString);

            Database = Client.GetDatabase(reservationDbContext.Value.DatabaseName);

            _Reservations = new Lazy<IMongoCollection<Reservation>> (() => Database.GetCollection<Reservation>("Reservations"));
            _Units = new Lazy<IMongoCollection<Unit>>(() => Database.GetCollection<Unit>("Units"));
        }
    }
}
