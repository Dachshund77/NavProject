using Backend.Interfaces;
using Commons.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Mocks
{
    public class NavBasketsServiceMock : INavBasketsService
    {
        public Basket ChangeProductCount(Basket basket, int basketID, int productID, int quantity)
        {
            return basket; //Yeah this ist just echoing.
        }

        public void DeleteBasket(int basketID)
        {
            //Maybe should return a bool?
        }

        public Basket GetBasket(int basketID)
        {
            return Basket.GetMockBasket(basketID);
        }

        public List<Basket> GetBasketsOfUser(string userName)
        {
            return User.GetMockUser(userName).Baskets.ToList();
        }

        public Basket PostBasket(Basket basket, string userName)
        {
            return basket; //just echoing
        }

        public Basket PutBasket(Basket basket, int basketID)
        {
            return basket; //just echoing
        }

        public Basket RemoveProductFromBasket(Basket basket, int basketID, int productID)
        {
            return basket; //just echoing
        }

       
    }
}
