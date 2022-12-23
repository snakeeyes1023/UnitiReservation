using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitiReservation.Core.Models.Stats
{
    public class TotalVacation
    {
        public int TotalUnits { get; set; }
        public int TotalUsed { get; set; }

        public decimal PourcentageVacation 
        {
            get
            {
                if (TotalUnits <= 0)
                {
                    return 0;
                }

                return Math.Round(Decimal.Divide(TotalUsed, TotalUnits) * 100, 2);
            }
        }
    }
}
