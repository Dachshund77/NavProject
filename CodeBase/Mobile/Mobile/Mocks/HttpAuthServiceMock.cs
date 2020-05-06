using Commons.Domain;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Mocks
{
    public class HttpAuthServiceMock : IHttpAuthService
    {
        public async Task<string> LogIn(User user)
        {
            List<Transaction> returnList = new List<Transaction>();
            User mockUser =  User.GetMockUser(user.UserName);

            if (mockUser != null && user.PlainPassword == mockUser.PlainPassword)
            {
                return "someKindOfJWTORSecurityToken";
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> LogOut(User user)
        {
            return true; //This would only work with some actualy authentication and shit
        }

        public async Task<bool> Register(User user)
        {
            return true; //Not really implemented in teh backend even... so idc
        }
    }
}
