using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Services
{
    public interface IHttpProductsService
    {
        Product GetProduct(int productID);
        List<Product> GetProductsOfBasket(int basketID);
    }
}
