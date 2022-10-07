using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Infrastructures;
using UnitiReservation.Core.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace UnitiReservation.Core.Services.UnitService
{
    public class UnitServices : IUnitServices
    {
        private readonly IReservationDbContext _DbContext;
        public UnitServices(IReservationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        /// <summary>
        /// Get all units
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Unit>> GetAllUnits()
        {
            return await _DbContext.Units.Find(x => true).ToListAsync();
        }

        /// <summary>
        /// Insert a new unit
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public async Task InsertUnit(Unit unit)
        {
            ValidateUnit(unit);

            await _DbContext.Units.InsertOneAsync(unit);
        }

        private static void ValidateUnit(Unit unit)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Unit>> GetFreeUnit()
        {
            return await _DbContext.Units.Find(x => x.Show).ToListAsync();
        }
    }
}
