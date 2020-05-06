using Commons.Domain;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Mocks
{
    public class HttpTransactionsServiceMock : IHttpTransactionsService
    {
        public async Task<Transaction> GetTransaction(int transactionID)
        {
            return Transaction.GetMockTransaction(transactionID);
        }

        public async Task<List<Transaction>> GetTransactionsOfBasket(int basketID)
        {
            return Basket.GetMockBasket(basketID).Transactions.ToList();
        }

        public async Task<List<Transaction>> GetTransactionsOfUser(string userName)
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
