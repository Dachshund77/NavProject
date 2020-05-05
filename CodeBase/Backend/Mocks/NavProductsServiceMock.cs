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
            return GetMockProduct(productID);
        }

        public List<Product> GetProductsOfBasket(int basketID)
        {
            List<Basket> baskets = NavBasketsServiceMock.GetMockBaskets();
            Basket selectedBasket = baskets.Where(x => x.ID == basketID).FirstOrDefault();
            return selectedBasket.Products.ToList();
            
        }

        public static Product GetMockProduct(int productID)
        {
            List<Product> products = GetMockProducts();
            return products[productID-1];
        }

        public static List<Product> GetMockProducts()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product(1, "Apple", "Green Apple", 5.99, 4,"fasdfsadfasf"));
            products.Add(new Product(2, "Bannana", "Blue Bananan", 8.99,5, "fasdfgsdnhrasfassadfasf"));
            products.Add(new Product(3, "Cat", "Red Care", 566.99,2, "afafukghkgsfa"));

            return products;
        }
    }
}
