using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitiReservation.Core.Infrastructures.Configurations.Authentication.Models;
using UnitiReservation.Core.Infrastructures.Data.Interfaces;
using UnitiReservation.Core.Models.Auth;
using UnitiReservation.Core.Models.Users;

namespace UnitiReservation.Core.Services.Users
{
    public interface IUserService
    {
        Task<Tokens?> Authenticate(UserAuthForm users);
        Task CreateAccount(UserCreationForm user);
    }
}
