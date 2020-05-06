using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public interface IHttpProductsService
    {
        Task<Product> GetProduct(string barcode, HttpClient httpClient);
        Task<List<Product>> GetProductsOfBasket(int basketID, HttpClient httpClient);
    }
}
