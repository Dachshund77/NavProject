using Backend.Interfaces;
using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class NavProductsService : INavProductsService
    {
        public Product GetProduct(string barcode)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsOfBasket(int basketID)
        {
            throw new NotImplementedException();
        }
    }
}
