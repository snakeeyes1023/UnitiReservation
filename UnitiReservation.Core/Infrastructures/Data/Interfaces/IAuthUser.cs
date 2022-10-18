using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitiReservation.Core.Infrastructures.Data.Interfaces
{
    public interface IAuthUser
    {
        string Username { get; }
        string Fullname { get; }
        bool Verify(string enteredPassword);
        void EncryptPassword(string passwordToEncrypt);
    }
}
