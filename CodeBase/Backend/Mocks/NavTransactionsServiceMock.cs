using Backend.Interfaces;
using Commons.Domain;
using System.Collections.Generic;
using System.Linq;


namespace Backend.Mocks
{
    public class NavTransactionsServiceMock : INavTransactionsService
    {
        public Transaction GetTransaction(int transactionID)
        {
            return Transaction.GetMockTransaction(transactionID);
        }

        public List<Transaction> GetTransactionsOfBasket(int basketID)
        {
            //List<Basket> baskets = NavBasketsServiceMock.GetMockBaskets();
            List<Basket> baskets = null;
            Basket selectedBasket = baskets.Where(x => x.ID == basketID).FirstOrDefault();
            return selectedBasket.Transactions.ToList();
        }

        public List<Transaction> GetTransactionsOfUser(string userName)
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
