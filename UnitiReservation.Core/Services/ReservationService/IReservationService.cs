using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Models.Entities;

namespace UnitiReservation.Core.Services.ReservationService
{
    public interface IReservationService
    {
        Task InsertReservation(string id, Reservation reservation);
    }
}
