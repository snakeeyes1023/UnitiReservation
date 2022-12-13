using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Infrastructures.Data.Entities;

namespace UnitiReservation.Core.Services.Units
{
    public interface IUnitService
    {
        Task<IEnumerable<UnitEntity>> GetAllUnits();

        Task<UnitEntity> InsertUnit(UnitEntity unit);

        Task<IEnumerable<UnitEntity>> GetFreeUnit();

        Task<UnitEntity> UpdateUnit(UnitEntity unit);

        Task Delete(string unitId);

        Task<UnitEntity> GetById(string id);

        Task<IEnumerable<UnitEntity>> GetBetween(decimal from, decimal to);
    }
}
