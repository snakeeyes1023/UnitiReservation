using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Models;

namespace UnitiReservation.Core.Services.ReservationService
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllReservations();
        Task InsertReservation(Reservation reservation);
        Task InsertReservation(Unit unit, Reservation reservation);


    }
}
