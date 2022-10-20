using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Infrastructures.Data.Interfaces;
using System.ComponentModel.DataAnnotations;
using UnitiReservation.Core.Helpers;
using Microsoft.AspNetCore.Identity;

namespace UnitiReservation.Core.Infrastructures.Data.Entities
{
    public class UserEntity : Entity, IAuthUser
    {
        [Required(ErrorMessage = AttributeLocalisation.REQUIRED)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = AttributeLocalisation.REQUIRED)]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = AttributeLocalisation.REQUIRED)]
        public string PasswordHash { private get; set; } = string.Empty;

        [Required(ErrorMessage = AttributeLocalisation.REQUIRED)]
        public string Firstname { get; set; } = string.Empty;

        [Required(ErrorMessage = AttributeLocalisation.REQUIRED)]
        public string Lastname { get; set; } = string.Empty;

        public string Fullname => $"{Firstname} {Lastname}";


        [BsonIgnoreIfNull]
        public List<UserConnection>? Logs { get; set; }

        public void AddLog(string ip)
        {
            if (Logs == null)
            {
                Logs = new List<UserConnection>(1);
            }

            Logs.Add(new UserConnection(ip));
        }

        public void EncryptPassword(string passwordToEncrypt)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(passwordToEncrypt);
        }

        public bool Verify(string enteredPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, PasswordHash);
        }
    }

    public class UserConnection : Entity
    {
        public UserConnection()
        {
            IpAddress = string.Empty;
        }

        public UserConnection(string ip)
        {
            IpAddress = ip;
        }

        public string IpAddress { get; set; }
    }
}
