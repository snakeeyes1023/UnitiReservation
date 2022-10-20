using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitiReservation.Core.Models.Auth
{
    public class UserAuthForm
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
