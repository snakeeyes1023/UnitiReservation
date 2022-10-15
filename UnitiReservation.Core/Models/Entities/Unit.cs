using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using UnitiReservation.Core.Models.Interface;
using UnitiReservation.Core.Models.Helper;
using UnitiReservation.Core.Models.Enums;

namespace UnitiReservation.Core.Models.Entities
{
    public class Unit : ModelValidate<Unit>, IHasId
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal DisplayPricing { get; set; }

        public bool Show { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Icon { get; set; } = string.Empty;

        public string Coordonnee { get; set; } = string.Empty;

        public int Quantity { get; set; } = 1;

        public bool IsTaxable { get; set; }

        public int TotalWatch { get; set; }

        public List<string> Wishlist { get; set; } = new List<string>();

        [MinLength(1)]
        public List<UnitType> Tags { get; set; } = new List<UnitType>();

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();


        #region VIRTUAL

        public string Summary
        {
            get
            {
                return $"{Name} {DisplayPricing}";
            }
        }

        #endregion
    }
}
