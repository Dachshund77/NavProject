using Backend.Interfaces;
using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class NavTransactionsService : INavTransactionsService
    {
        public Transaction GetTransaction(int transactionID)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetTransactionsOfBasket(int basketID)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetTransactionsOfUser(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
