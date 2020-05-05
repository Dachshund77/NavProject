using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public interface IHttpProductsService
    {
        Task<Product> GetProduct(string barcode);
        Task<List<Product>> GetProductsOfBasket(int basketID);
    }
}
