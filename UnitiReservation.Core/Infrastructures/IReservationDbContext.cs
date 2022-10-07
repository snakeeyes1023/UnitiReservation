using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Models;

namespace UnitiReservation.Core.Infrastructures
{
    public interface IReservationDbContext
    {
        IMongoCollection<Reservation> Reservations { get; }
        IMongoCollection<Unit> Units { get; }

    }
}
