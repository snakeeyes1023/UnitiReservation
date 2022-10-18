using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Infrastructures.Data.Entities;

namespace UnitiReservation.Core.Services.Reservations
{
    public interface IReservationService
    {
        Task InsertReservation(string id, ReservationEntity reservation);
    }
}
