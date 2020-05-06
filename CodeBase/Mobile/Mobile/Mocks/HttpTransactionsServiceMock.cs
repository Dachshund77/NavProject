using Commons.Domain;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Mocks
{
    public class HttpTransactionsServiceMock : IHttpTransactionsService
    {
        public async Task<Transaction> GetTransaction(int transactionID, HttpClient httpClient = null)
        {
            return Transaction.GetMockTransaction(transactionID);
        }

        public async Task<List<Transaction>> GetTransactionsOfBasket(int basketID, HttpClient httpClient = null)
        {
            return Basket.GetMockBasket(basketID).Transactions.ToList();
        }

        public async Task<List<Transaction>> GetTransactionsOfUser(string userName, HttpClient httpClient = null)
        {
            List<Transaction> returnList = new List<Transaction>();

            User user = User.GetMockUser(userName);
            foreach (Basket b in user.Baskets) //Can i write this as LINQ query?
            {
                returnList.AddRange(b.Transactions);
            }
            return returnList;
        }
    }
}
