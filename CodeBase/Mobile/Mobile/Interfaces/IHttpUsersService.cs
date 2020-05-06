using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public interface IHttpUsersService
    {
        Task<User> GetUser(string userName, HttpClient httpClient);
    }
}
