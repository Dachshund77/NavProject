using Backend.Interfaces;
using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Mocks
{
    public class NavAuthServiceMock : INavAuthService
    {
        public string LogIn(User user)
        {
            List<Transaction> returnList = new List<Transaction>();
            User mockUser = NavUsersServiceMock.GetMockUser(user.UserName);

            if(mockUser != null && user.PlainPassword == mockUser.PlainPassword)
            {
                return "someKindOfJWTORSecurityToken";
            }
            else
            {
                return null;
            }
        }

        public void LogOut(User user)
        {
            //Should probably return some kind of signature... ohhh well
        }

        public void Register(User user)
        {
            //Void is bad m'kay :D
        }
    }
}
