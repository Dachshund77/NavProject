using Backend.Interfaces;
using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Mocks
{
    public class NavProductsServiceMock : INavProductsService
    {
        public Product GetProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsOfBasket(int basketID)
        {
            throw new NotImplementedException();
        }

        public static List<Product> GetMockProduct()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product(1, "Apple", "Green Apple", 5.99, "fasdfsadfasf"));
            products.Add(new Product(2, "Bannana", "Blue Bananan", 8.99, "fasdfgsdnhrasfassadfasf"));
            products.Add(new Product(3, "Cat", "Red Care", 566.99, "afafukghkgsfa"));

            return products;
        }
    }
}
