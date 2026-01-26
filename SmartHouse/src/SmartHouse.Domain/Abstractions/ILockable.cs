using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Domain.Abstractions
{
    public interface ILockable
    {
        bool IsLocked { get; }

        void ChangePIN(int newPin); 
    }
}
