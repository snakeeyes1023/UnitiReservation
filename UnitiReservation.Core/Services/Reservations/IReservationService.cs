using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Infrastructures.Data.Entities;
using UnitiReservation.Core.Models.Reservation;

namespace UnitiReservation.Core.Services.Reservations
{
    public interface IReservationService
    {
        Task InsertReservation(string id, ReservationModel reservation);
    }
}
