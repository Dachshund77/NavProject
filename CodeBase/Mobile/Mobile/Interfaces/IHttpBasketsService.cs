using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Services
{
    public interface IHttpBasketsService
    {
        Basket PostBasket(Basket basket, string userName);
        Basket PutBasket(Basket basket, int basketID);
        Basket ChangeProductCount(Basket basket, int basketID, int productID, int quantity);
        Basket RemoveProductFromBasket(Basket basket, int basketID, int productID);
        void DeleteBasket(int basketID);
        Basket GetBasket(int basketID);
        List<Basket> GetBasketsOfUser(string userName);
    }
}
