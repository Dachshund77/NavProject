using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public interface IHttpBasketsService
    {
        Task<Basket> PostBasket(Basket basket, string userName);
        Task<Basket> PutBasket(Basket basket, int basketID);
        Task<Basket> ChangeProductCount(Basket basket, int basketID, int productID, int quantity);
        Task<Basket> RemoveProductFromBasket(Basket basket, int basketID, int productID);
        Task<bool> DeleteBasket(int basketID);
        Task<Basket> GetBasket(int basketID);
        Task<List<Basket>> GetBasketsOfUser(string userName);
    }
}
