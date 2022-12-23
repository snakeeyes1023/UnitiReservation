using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Infrastructures.Data.DbContext;
using UnitiReservation.Core.Models.Stats;

namespace UnitiReservation.Core.Services.Statistics
{

    public class StatistiqueService : IStatistiqueService
    {
        private readonly IReservationDbContext _DbContext;
        public StatistiqueService(IReservationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<TotalVacation> GetPourcentageVacation()
        {
            TotalVacation totalVacantion = new();

            var units = await _DbContext.Units.Find(x => true).ToListAsync();

            foreach (var unit in units)
            {
                totalVacantion.TotalUnits += unit.Quantity;
                totalVacantion.TotalUsed += unit.TotalInUsed;
            }

            return totalVacantion;
        }

        public async Task<AverageReservationRange> GetAverageTimeReservation()
        {
            var units = await _DbContext.Units.Find(x => true).ToListAsync();

            double averageTimeReservation = 0;
            double totalCount = 0;

            foreach (var unit in units.Where(x => x.Reservations.Any()))
            {
                averageTimeReservation += unit.Reservations.Average(x => x.TotalDays());
                totalCount++;
            }

            return new AverageReservationRange()
            {
                Days = averageTimeReservation / totalCount
            };
        }
    }
}