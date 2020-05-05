using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Services
{
    public interface IHttpAuthService
    {
        string LogIn(User user);
        bool LogOut(User user);
        bool Register(User user);
    }
}
