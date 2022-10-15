using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitiReservation.Core.Models.Entities
{
    public class UserApiKey
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string UserName { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
