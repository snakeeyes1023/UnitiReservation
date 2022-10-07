using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Models;

namespace UnitiReservation.Core.Services.UnitService
{
    public interface IUnitServices
    {
        Task<IEnumerable<Unit>> GetAllUnits();

        Task InsertUnit(Unit unit);

        Task<IEnumerable<Unit>> GetFreeUnit();
    }
}
