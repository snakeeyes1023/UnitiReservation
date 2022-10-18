using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Infrastructures.Data.Enums;

namespace UnitiReservation.Core.Models.Stats
{
    public class TotalAvailablePerStatus
    {
        public List<UnitType> Types { get; set; }
        public int Total { get; set; }
    }
}
