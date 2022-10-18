using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Infrastructures.Data.Entities;

namespace UnitiReservation.Core.Infrastructures.Data.DbContext
{
    public interface IReservationDbContext
    {
        IMongoCollection<UnitEntity> Units { get; }
        IMongoCollection<UserEntity> Users { get; }
        IMongoCollection<RequestLogEntity> RequestLogs { get; }

    }
}
