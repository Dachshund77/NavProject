using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Services
{
    public interface IHttpTransactionsService
    {
        Transaction GetTransaction(int transactionID);
        List<Transaction> GetTransactionsOfBasket(int basketID);
        List<Transaction> GetTransactionsOfUser(string userName);
    }
}
