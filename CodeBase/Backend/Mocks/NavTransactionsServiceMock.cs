using Backend.Interfaces;
using Commons.Domain;
using Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Backend.Mocks
{
    public class NavTransactionsServiceMock : INavTransactionsService
    {
        public Transaction GetTransaction(int transactionID)
        {
            return GetMockTransaction(transactionID);
        }

        public List<Transaction> GetTransactionsOfBasket(int basketID)
        {
            List<Basket> baskets = NavBasketsServiceMock.GetMockBaskets();
            Basket selectedBasket = baskets.Where(x => x.ID == basketID).FirstOrDefault();
            return selectedBasket.Transactions.ToList();
        }

        public List<Transaction> GetTransactionsOfUser(string userName)
        {
            List<Transaction> returnList = new List<Transaction>();

            User user = NavUsersServiceMock.GetMockUser(userName);
            foreach (Basket b in user.Baskets) //Can i write this as LINQ query?
            {
                returnList.AddRange(b.Transactions);              
            }
            return returnList;
        }

        public static Transaction GetMockTransaction(int tranactionID)
        {
            List<Transaction> transactions = GetMockTransactions();
            return transactions[tranactionID - 1];
        }

        public static List<Transaction> GetMockTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();

            transactions.Add(new Transaction(1, new DateTime(2020, 1, 15), PaymentType.Card, 700));
            transactions.Add(new Transaction(2, new DateTime(2019, 4, 8), PaymentType.Check, 70));
            transactions.Add(new Transaction(3, new DateTime(2020, 11, 4), PaymentType.Card, 7200));
            transactions.Add(new Transaction(4, new DateTime(2028, 3, 7), PaymentType.Card, 800));

            return transactions;
        }
    }
}
