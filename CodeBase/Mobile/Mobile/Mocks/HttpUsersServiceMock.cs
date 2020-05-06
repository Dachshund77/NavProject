using Commons.Domain;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Mocks
{
    public class HttpUsersServiceMock : IHttpUsersService
    {
        public async Task<User> GetUser(string userName)
        {
            return User.GetMockUser(userName);
        }
    }
}
