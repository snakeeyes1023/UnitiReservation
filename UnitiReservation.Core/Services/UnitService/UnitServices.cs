using UnitiReservation.Core.Infrastructures;
using MongoDB.Driver;
using System.Reflection.Metadata;
using MongoDB.Bson;
using UnitiReservation.Core.Models.Entities;

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
            var validationResult = unit.Validate();

            if (!validationResult.Item1)
            {
                throw new ArgumentException("Erreur de validation", validationResult.Item2.ToString());
            }

            await _DbContext.Units.InsertOneAsync(unit);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Unit>> GetFreeUnit()
        {
            return await _DbContext.Units.Find(x => x.Show).ToListAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public async Task UpdateUnit(Unit unit)
        {
            var filter = Builders<Unit>.Filter.Eq(x => x.Id, unit.Id);

            var update = Builders<Unit>.Update
                .Set(x => x, unit);
           
            await _DbContext.Units.UpdateOneAsync(filter, update);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public async Task Delete(Unit unit)
        {
            await _DbContext.Units.DeleteOneAsync(x => x.Id == unit.Id);         
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Unit> GetById(string id)
        {
           return (await _DbContext.Units.FindAsync(x => x.Id == id)).FirstOrDefault();
        }

        public async Task<IEnumerable<Unit>> GetBetween(decimal from, decimal to)
        {
            return await _DbContext.Units.Find(x => x.DisplayPricing > from && x.DisplayPricing < to).ToListAsync();
        }
    }
}
