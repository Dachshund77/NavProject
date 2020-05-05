using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public interface IHttpAuthService
    {
        Task<string> LogIn(User user);
        Task<bool> LogOut(User user);
        Task<bool> Register(User user);
    }
}
