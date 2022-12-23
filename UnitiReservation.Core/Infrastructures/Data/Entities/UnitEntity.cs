using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using UnitiReservation.Core.Models.Helper;
using UnitiReservation.Core.Helpers;
using UnitiReservation.Core.Infrastructures.Data.Enums;

namespace UnitiReservation.Core.Infrastructures.Data.Entities
{
    public class UnitEntity : Entity
    {

        #region required field

        [Required(ErrorMessage = AttributeLocalisation.REQUIRED)]
        public string Name { get; set; } = null!;


        [Required(ErrorMessage = AttributeLocalisation.REQUIRED)]
        public decimal DisplayPricing { get; set; }


        [Required(ErrorMessage = AttributeLocalisation.REQUIRED)]
        public string Description { get; set; } = string.Empty;


        [Required(ErrorMessage = AttributeLocalisation.REQUIRED)]
        public int Quantity { get; set; } = 1;


        [Required(ErrorMessage = AttributeLocalisation.REQUIRED)]
        public bool IsTaxable { get; set; }


        [MinLength(1)]
        [Required(ErrorMessage = AttributeLocalisation.REQUIRED)]
        public List<UnitType> Tags { get; set; } = new List<UnitType>();


        #endregion
        public bool Show { get; set; }

        public string Icon { get; set; } = string.Empty;

        public string Coordonnee { get; set; } = string.Empty;


        public int TotalWatch { get; set; }

        public List<string> Wishlist { get; set; } = new List<string>();


        public List<ReservationEntity> Reservations { get; set; } = new List<ReservationEntity>();


        #region VIRTUAL

        public string Summary
        {
            get
            {
                return $"{Name} {DisplayPricing}";
            }
        }

        public int TotalInUsed => Reservations.Count(x => x.CurrentlyInReservation);

        public int TotalAvailable => Quantity - TotalInUsed;

        #endregion
    }
}
