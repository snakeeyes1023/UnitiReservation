using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using UnitiReservation.Core.Helpers;

namespace UnitiReservation.Core.Infrastructures.Data.Entities
{
    public class ReservationEntity : Entity
    {
        [Required(ErrorMessage = AttributeLocalisation.REQUIRED)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = AttributeLocalisation.REQUIRED)]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsEnded
        {
            get
            {
                return EndDate == null || EndDate.HasValue && EndDate.Value < DateTime.Now;
            }
        }

        public bool CurrentlyInReservation
        {
            get
            {
                return StartDate >= DateTime.Now && !IsEnded;
            }
        }
    }
}
