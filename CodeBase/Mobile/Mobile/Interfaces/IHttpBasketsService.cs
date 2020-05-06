using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public interface IHttpBasketsService
    {
        Task<Basket> PostBasket(Basket basket, string userName, HttpClient httpClient);
        Task<Basket> PutBasket(Basket basket, int basketID, HttpClient httpClient);
        Task<Basket> ChangeProductCount(Basket basket, int basketID, int productID, int quantity, HttpClient httpClient);
        Task<Basket> RemoveProductFromBasket(Basket basket, int basketID, string barcode, HttpClient httpClient);
        Task<bool> DeleteBasket(int basketID, HttpClient httpClient);
        Task<Basket> GetBasket(int basketID, HttpClient httpClient);
        Task<List<Basket>> GetBasketsOfUser(string userName, HttpClient httpClient);
    }
}
