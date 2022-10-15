using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitiReservation.Core.Models.Enums
{
    public enum UnitType
    {
        [Description("Chauffée")]
        Hot = 0,

        [Description("Accès en tout temps")]
        AllTimeAccess = 1,
    }
}
