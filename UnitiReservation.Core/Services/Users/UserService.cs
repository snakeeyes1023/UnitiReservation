using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Infrastructures.Configurations.Authentication.Models;
using UnitiReservation.Core.Infrastructures.Data.DbContext;
using UnitiReservation.Core.Infrastructures.Data.Entities;
using UnitiReservation.Core.Infrastructures.Data.Interfaces;
using UnitiReservation.Core.Models.Auth;
using UnitiReservation.Core.Models.Users;

namespace UnitiReservation.Core.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IReservationDbContext _dbContext;

        public UserService(IConfiguration configuration, IReservationDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }
        public async Task<Tokens?> Authenticate(UserAuthForm user)
        {
            IAuthUser userEntity = await _dbContext.Users.Find(x => x.Username == user.UsernameOrEmail || x.Email == user.UsernameOrEmail).FirstOrDefaultAsync();

            if (userEntity == null || !userEntity.Verify(user.Password))
            {
                return null;
            }

            return GenerateToken(userEntity);

        }

        public async Task CreateAccount(UserCreationForm user)
        {
            var userEntity = new UserEntity()
            {
                Username = user.Username,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email           
            };

            userEntity.EncryptPassword(user.Password);

            await _dbContext.Users.InsertOneAsync(userEntity);
        }

        private Tokens GenerateToken(IAuthUser userEntity)
        {
            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, userEntity.Fullname)
              }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new Tokens { Token = tokenHandler.WriteToken(token), UserName = userEntity.Username };
        }
    }
}
