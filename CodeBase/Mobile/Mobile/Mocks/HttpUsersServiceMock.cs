using Commons.Domain;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Mocks
{
    public class HttpUsersServiceMock : IHttpUsersService
    {
        public async Task<User> GetUser(string userName, HttpClient httpClient = null)
        {
            return User.GetMockUser(userName);
        }
    }
}
