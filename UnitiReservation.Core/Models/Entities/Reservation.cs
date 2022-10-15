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

namespace UnitiReservation.Core.Models.Entities
{
    public class Reservation : ModelValidate<Reservation>, IHasId
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsEnded
        {
            get
            {
                return EndDate == null || EndDate.HasValue && EndDate.Value < DateTime.Now;
            }
        }
    }
}
