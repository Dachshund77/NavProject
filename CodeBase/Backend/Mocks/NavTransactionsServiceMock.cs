using Backend.Interfaces;
using Commons.Domain;
using Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Mocks
{
    public class NavTransactionsServiceMock : INavTransactionsService
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
