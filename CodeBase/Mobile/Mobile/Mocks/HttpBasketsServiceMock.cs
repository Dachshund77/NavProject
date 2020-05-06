using Commons.Domain;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Mocks
{
    public class HttpBasketsServiceMock : IHttpBasketsService
    {
        public async Task<Basket> ChangeProductCount(Basket basket, int basketID, int productID, int quantity, HttpClient httpClient = null)
        {
            return basket; //We just echo, we might not even need that if remeber 
        }

        public async Task<bool> DeleteBasket(int basketID, HttpClient httpClient = null)
        {
            return true; //Is not even need i think
        }

        public async Task<Basket> GetBasket(int basketID, HttpClient httpClient = null)
        {
            return Basket.GetMockBasket(basketID);
        }

        public async Task<List<Basket>> GetBasketsOfUser(string userName, HttpClient httpClient = null)
        { 
            return User.GetMockUser(userName).Baskets.ToList();
        }

        public async Task<Basket> PostBasket(Basket basket, string userName, HttpClient httpClient = null)
        {
            return basket; //We just echo
        }

        public async Task<Basket> PutBasket(Basket basket, int basketID, HttpClient httpClient = null)
        {
            return basket; //We just echo
        }

        public async Task<Basket> RemoveProductFromBasket(Basket basket, int basketID, string barcode, HttpClient httpClient = null)
        {
            return basket; //We just echo
        }
    }
}
