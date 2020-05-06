using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public interface IHttpTransactionsService
    {
        Task<Transaction> GetTransaction(int transactionID, HttpClient httpClient);
        Task<List<Transaction>> GetTransactionsOfBasket(int basketID, HttpClient httpClient);
        Task<List<Transaction>> GetTransactionsOfUser(string userName, HttpClient httpClient);
    }
}
