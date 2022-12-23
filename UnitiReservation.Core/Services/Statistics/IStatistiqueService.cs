using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Models.Stats;

namespace UnitiReservation.Core.Services.Statistics
{
    public interface IStatistiqueService
    {
        Task<TotalVacation> GetPourcentageVacation();
        Task<AverageReservationRange> GetAverageTimeReservation();
    }
}
