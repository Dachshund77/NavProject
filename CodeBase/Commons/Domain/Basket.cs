
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Commons.Domain
{
    public class Basket : BaseDomain
    {
        private int id;
        private bool isPaid;
        private ObservableCollection<Product> products;
        private ObservableCollection<Transaction> transactions;
        private double amount;

        public int ID
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }
        public bool IsPaid
        {
            get { return isPaid; }
            set { SetProperty(ref isPaid, value); }
        }
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { SetProperty(ref products, value); }
        }
        public ObservableCollection<Transaction> Transactions
        {
            get { return transactions; }
            set { SetProperty(ref transactions, value); }
        }
        public double Amount
        {
            get { return amount; }
            set { SetProperty(ref amount, value); }
        }

        public Basket()
        {
            Products = new ObservableCollection<Product>();
            Transactions = new ObservableCollection<Transaction>();
        }

        /// <summary>
        /// Copy constructor, create deep copy.
        /// </summary>
        /// <param name="other"></param>
        public Basket(Basket other)
            : this()
        {
            this.ID = other.ID;
            this.IsPaid = other.IsPaid;
            //Clone Products
            foreach (Product p in other.Products)
            {
                this.Products.Add(new Product(p));
            }
            //Clone Transactions
            foreach (Transaction t in other.Transactions)
            {
                this.Transactions.Add(new Transaction(t));
            }
            this.Amount = other.Amount;
        }

        public bool IsValid(out IEnumerable<string> invalidReasons)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> InvalidReasons()
        {
            throw new NotImplementedException();
        }

        public bool IsValidID(out IEnumerable<string> invalidReasons)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> InvalidIDReasons()
        {
            throw new NotImplementedException();
        }

        public bool IsValidIsPaid(out IEnumerable<string> invalidReasons)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> InvalidIsPaidReasons()
        {
            throw new NotImplementedException();
        }

        public bool IsValidProducts(out IEnumerable<string> invalidReasons)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> InvalidProductsReasons()
        {
            throw new NotImplementedException();
        }

        public bool IsValidTransactions(out IEnumerable<string> invalidReasons)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> InvalidTransactionsReasons()
        {
            throw new NotImplementedException();
        }

        public bool IsValidAmount(out IEnumerable<string> invalidReasons)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> InvalidAmountReasons()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Object of this kind is equal if id is the same.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Ture if equal</returns>
        public override bool Equals(object obj)
        {
            var other = obj as Basket;
            //Null Test
            if (other == null)
            {
                return false;
            }

            //Same reference
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.ID != other.ID)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 9) + ID.GetHashCode();
            return hash;
        }
    }
}
