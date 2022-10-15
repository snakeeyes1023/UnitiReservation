using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Models.Entities;

namespace UnitiReservation.Core.Infrastructures
{
    public interface IReservationDbContext
    {
        IMongoCollection<Unit> Units { get; }
        IMongoCollection<UserApiKey> UserApiKeys { get; }

    }
}
