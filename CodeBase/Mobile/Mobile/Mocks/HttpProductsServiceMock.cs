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
    public class HttpProductsServiceMock : IHttpProductsService
    {
        public async Task<Product> GetProduct(string barcode, HttpClient httpClient = null)
        {
            return Product.GetMockProduct(barcode);
        }

        public async Task<List<Product>> GetProductsOfBasket(int basketID, HttpClient httpClient = null)
        {
            return Basket.GetMockBasket(basketID).Products.ToList();
        }
    }
}
