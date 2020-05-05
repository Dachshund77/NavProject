using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public interface INavAuthService
    {
        string LogIn(User user);
        void LogOut(User user);
        void Register(User user);
    }
}
