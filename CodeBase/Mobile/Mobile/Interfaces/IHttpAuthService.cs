using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public interface IHttpAuthService
    {
        Task<string> LogIn(User user, HttpClient httpClient);
        Task<bool> LogOut(User user, HttpClient httpClient);
        Task<bool> Register(User user, HttpClient httpClient);
    }
}
