using Backend.Interfaces;
using Commons.Domain;

namespace Backend.Mocks
{
    public class NavUsersServiceMock : INavUsersService
    {
        public User GetUser(string userName)
        {
            return User.GetMockUser(userName);
        }

        
    }
}
