using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public interface IHttpTransactionsService
    {
        Task<Transaction> GetTransaction(int transactionID);
        Task<List<Transaction>> GetTransactionsOfBasket(int basketID);
        Task<List<Transaction>> GetTransactionsOfUser(string userName);
    }
}
