using Backend.Interfaces;
using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Mocks
{
    public class NavUsersServiceMock : INavUsersService
    {
        public User GetUser(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
