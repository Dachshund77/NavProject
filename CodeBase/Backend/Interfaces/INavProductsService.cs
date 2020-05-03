using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public interface INavProductsService
    {
        Product GetProduct(int productID);

        List<Product> GetProductsOfBasket(int basketID);
    }
}
