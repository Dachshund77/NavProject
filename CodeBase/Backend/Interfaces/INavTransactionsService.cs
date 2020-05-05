using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public interface INavTransactionsService
    {
        Transaction GetTransaction(int transactionID);

        List<Transaction> GetTransactionsOfBasket(int basketID);

        List<Transaction> GetTransactionsOfUser(string userName);
    }
}
