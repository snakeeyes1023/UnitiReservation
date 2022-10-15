using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Models.CustomModels.Stats;

namespace UnitiReservation.Core.Services.StatistiqueService
{
    public interface IStatistiqueService
    {
        AveragePriceByAvailable AveragePricePerUnitStatus();
        TotalAvailablePerStatus TotalAvailablePerUnitStatus();
    }
}
