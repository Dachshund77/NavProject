using Backend.Interfaces;
using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

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
            return GetMockBasket(basketID);
        }

        public List<Basket> GetBasketsOfUser(string userName)
        {
            return NavUsersServiceMock.GetMockUser(userName).Baskets.ToList();
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

        public static Basket GetMockBasket(int basketID)
        {
            List<Basket> baskets = GetMockBaskets();
            return baskets[basketID - 1];
        }

        public static List<Basket> GetMockBaskets()
        {
            //Get needed values
            List<Product> mockProducts = NavProductsServiceMock.GetMockProducts();
            List<Transaction> mockTransactions = NavTransactionsServiceMock.GetMockTransactions();

            //Init
            List<Basket> baskets = new List<Basket>();

            baskets.Add(new Basket(
                1,
                false,
                new ObservableCollection<Product>
                {
                     mockProducts[0],
                     mockProducts[2]
                },
                new ObservableCollection<Transaction>
                {
                    mockTransactions[1]
                },
                300));

            baskets.Add(new Basket(
                2,
                true,
                new ObservableCollection<Product>
                {
                     mockProducts[1] ,
                     mockProducts[2]
                },
                new ObservableCollection<Transaction>
                {
                    mockTransactions[2]
                },
                300));

            baskets.Add(new Basket(
                3,
                false,
                new ObservableCollection<Product>
                {
                     mockProducts[0]
                },
                new ObservableCollection<Transaction>
                {
                },
                400));

            return baskets;
        }
    }
}
