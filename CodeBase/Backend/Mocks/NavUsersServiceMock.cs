using Backend.Interfaces;
using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Mocks
{
    public class NavUsersServiceMock : INavUsersService
    {
        public User GetUser(string userName)
        {
            return GetMockUser(userName);
        }

        public static User GetMockUser(string userName)
        {
            List<User> users = GetMockUsers();         
            return users.Where(x => x.UserName == userName).FirstOrDefault();
        }

        public static List<User> GetMockUsers()
        {
            //init
            List<Basket> mockBasket = NavBasketsServiceMock.GetMockBaskets();
            List<User> mockUser = new List<User>();

            //Build
            mockUser.Add(new User(
                "Peter",
                "1334",
                "xas@google.com",
                new ObservableCollection<Basket>
                { 
                    mockBasket[0],
                    mockBasket[1]
                }));

            mockUser.Add(new User(
                "Sven",
                "133224",
                "xasffas@google.com",
                new ObservableCollection<Basket>
                {
                    mockBasket[2]
                }));

            mockUser.Add(new User(
                "Franz",
                "21",
                "Fraaaa@google.com",
                new ObservableCollection<Basket>
                {
                }));

            //return
            return mockUser;
        }
    }
}
