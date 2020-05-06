using Backend.Interfaces;
using Commons.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Mocks
{
    public class NavProductsServiceMock : INavProductsService
    {
        public Product GetProduct(string barcode)
        {

            return Product.GetMockProduct(barcode);
        }

        public List<Product> GetProductsOfBasket(int basketID)
        {
            List<Basket> baskets = Basket.GetMockBaskets();
            Basket selectedBasket = baskets.Where(x => x.ID == basketID).FirstOrDefault();
            return selectedBasket.Products.ToList();
            
        }

       
    }
}
