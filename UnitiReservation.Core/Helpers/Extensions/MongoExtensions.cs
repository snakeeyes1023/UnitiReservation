using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Infrastructures.Data.Entities;

namespace UnitiReservation.Core.Helpers.Extensions
{
    public static class MongoExtensions
    {
        public static UpdateDefinition<UnitEntity> ApplyMultiFields(this UpdateDefinitionBuilder<UnitEntity> builder, UnitEntity obj)
        {
            UpdateDefinition<UnitEntity> definition = builder
                .Set(x => x.Name, obj.Name)
                .Set(x => x.Description, obj.Description)
                .Set(x => x.DisplayPricing, obj.DisplayPricing)
                .Set(x => x.Show, obj.Show)
                .Set(x => x.Quantity, obj.Quantity)
                .Set(x => x.Tags, obj.Tags)
                .Set(x => x.IsTaxable, obj.IsTaxable);

            return definition;
        }
    }
}
