﻿using Backend.Interfaces;
using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class NavBasketsService : INavBasketsService
    {
        public Basket ChangeProductCount(Basket basket, int basketID, int productID, int quantity)
        {
            throw new NotImplementedException();
        }

        public void DeleteBasket(int basketID)
        {
            throw new NotImplementedException();
        }

        public Basket GetBasket(int basketID)
        {
            throw new NotImplementedException();
        }

        public List<Basket> GetBasketsOfUser(string userName)
        {
            throw new NotImplementedException();
        }

        public Basket PostBasket(Basket basket, string userName)
        {
            throw new NotImplementedException();
        }

        public Basket PutBasket(Basket basket, int basketID)
        {
            throw new NotImplementedException();
        }

        public Basket RemoveProductFromBasket(Basket basket, int basketID, string barcode)
        {
            throw new NotImplementedException();
        }
    }
}
