using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UnitiReservation.Core.Infrastructures.Settings;
using UnitiReservation.Core.Models.Entities;

namespace UnitiReservation.Core.Infrastructures
{
    public class ReservationDbContext : IReservationDbContext
    {
        private readonly Lazy<IMongoCollection<Unit>> _Units;
        public IMongoCollection<Unit> Units { get { return _Units.Value; } }


        private readonly Lazy<IMongoCollection<UserApiKey>> _UserApiKeys;
        public IMongoCollection<UserApiKey> UserApiKeys { get { return _UserApiKeys.Value; } }


        private IMongoClient Client;
        private IMongoDatabase Database;


        public ReservationDbContext(IOptions<UnitiReservationDatabaseSettings> reservationDbContext)
        {
            Client = new MongoClient(reservationDbContext.Value.ConnectionString);

            Database = Client.GetDatabase(reservationDbContext.Value.DatabaseName);

            _Units = new Lazy<IMongoCollection<Unit>>(() => Database.GetCollection<Unit>("Units"));
            _UserApiKeys = new Lazy<IMongoCollection<UserApiKey>>(() => Database.GetCollection<UserApiKey>("UserApiKeys"));
        }
    }
}
