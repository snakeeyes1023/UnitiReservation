using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UnitiReservation.Core.Models
{
    public class Unit
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string UnitName { get; set; } = null!;

        public decimal Pricing { get; set; }

        public bool Show { get; set; }

        public string Description
        {
            get
            {
                return $"{Pricing} {UnitName}";
            }
        }

        public bool Validate()
        {
            var context = new ValidationContext(this, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(this, context, validationResults, true);
        }
    }
}
