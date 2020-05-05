using Backend.Interfaces;
using Commons.Domain;
using System.Collections.Generic;

namespace Backend.Mocks
{
    public class NavAuthServiceMock : INavAuthService
    {
        public string LogIn(User user)
        {
            List<Transaction> returnList = new List<Transaction>();
            User mockUser = User.GetMockUser(user.UserName);

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
