using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UnitiReservation.Core.Infrastructures.Data.Entities;
using UnitiReservation.Core.Infrastructures.Settings;

namespace UnitiReservation.Core.Infrastructures.Data.DbContext
{
    public class ReservationDbContext : IReservationDbContext
    {
        #region Collections

        private readonly Lazy<IMongoCollection<UnitEntity>> _Units;
        public IMongoCollection<UnitEntity> Units { get { return _Units.Value; } }


        private readonly Lazy<IMongoCollection<UserEntity>> _Users;
        public IMongoCollection<UserEntity> Users { get { return _Users.Value; } }


        private readonly Lazy<IMongoCollection<RequestLogEntity>> _RequestLogs;
        public IMongoCollection<RequestLogEntity> RequestLogs { get { return _RequestLogs.Value; } }

        #endregion

        private IMongoClient Client;
        private IMongoDatabase Database;


        public ReservationDbContext(IOptions<UnitiReservationDatabaseSettings> reservationDbContext)
        {
            Client = new MongoClient(reservationDbContext.Value.ConnectionString);

            Database = Client.GetDatabase(reservationDbContext.Value.DatabaseName);

            _Units = new Lazy<IMongoCollection<UnitEntity>>(() => Database.GetCollection<UnitEntity>("Units"));
            _Users = new Lazy<IMongoCollection<UserEntity>>(() => Database.GetCollection<UserEntity>("Users"));
            _RequestLogs = new Lazy<IMongoCollection<RequestLogEntity>>(() => Database.GetCollection<RequestLogEntity>("RequestLogs"));
        }
    }
}
