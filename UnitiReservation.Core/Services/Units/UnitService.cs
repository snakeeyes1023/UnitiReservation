using MongoDB.Driver;
using System.Reflection.Metadata;
using MongoDB.Bson;
using UnitiReservation.Core.Infrastructures.Data.DbContext;
using UnitiReservation.Core.Infrastructures.Data.Entities;
using UnitiReservation.Core.Helpers.Extensions;

namespace UnitiReservation.Core.Services.Units
{
    public class UnitService : IUnitService
    {
        private readonly IReservationDbContext _DbContext;
        public UnitService(IReservationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        /// <summary>
        /// Get all units
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UnitEntity>> GetAllUnits()
        {
            return await _DbContext.Units.Find(x => true).ToListAsync();
        }

        /// <summary>
        /// Insert a new unit
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public async Task<UnitEntity> InsertUnit(UnitEntity unit)
        {
            await _DbContext.Units.InsertOneAsync(unit);

            return unit;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UnitEntity>> GetFreeUnit()
        {
            return await _DbContext.Units.Find(x => x.Show).ToListAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public async Task<UnitEntity> UpdateUnit(UnitEntity unit)
        {
            var filter = Builders<UnitEntity>.Filter.Eq(x => x.Id, unit.Id);

            var update = Builders<UnitEntity>.Update.ApplyMultiFields(unit);

            await _DbContext.Units.UpdateOneAsync(filter, update);

            return unit;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public async Task Delete(string unitId)
        {
            await _DbContext.Units.DeleteOneAsync(x => x.Id == unitId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UnitEntity> GetById(string id)
        {
            return (await _DbContext.Units.FindAsync(x => x.Id == id)).FirstOrDefault();
        }

        public async Task<IEnumerable<UnitEntity>> GetBetween(decimal from, decimal to)
        {
            return await _DbContext.Units.Find(x => x.DisplayPricing >= from && x.DisplayPricing <= to).ToListAsync();
        }

        public async Task UpdateUnitVisibilty(string id, bool newVisibilty)
        {
            var filter = Builders<UnitEntity>.Filter.Eq(x => x.Id, id);

            var update = Builders<UnitEntity>.Update.Set(x => x.Show, newVisibilty);

            var result = await _DbContext.Units.UpdateOneAsync(filter, update);
        }
    }
}
