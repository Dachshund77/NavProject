
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


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
            //Basically just makes sure that the lists are initalised
            if(Products == null)
            {
                
                Products = new ObservableCollection<Product>();
            }
            if (Transactions == null)
            {
                Transactions = new ObservableCollection<Transaction>();
            }
        }

        public Basket(int id, bool isPaid, ObservableCollection<Product> products, ObservableCollection<Transaction> transactions, double amount)
            : this()
        {
            ID = id;
            IsPaid = isPaid;
            Products = products;
            Transactions = transactions;
            Amount = amount;
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
                this.Products.Add(p);
            }
            //Clone Transactions
            foreach (Transaction t in other.Transactions)
            {
                this.Transactions.Add(new Transaction(t));
            }
            this.Amount = other.Amount;
        }

        public bool IsValid(out List<string> invalidReasons)
        {
            invalidReasons = InvalidReasons();
            if (invalidReasons.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> InvalidReasons()
        {
            //Init values
            List<string> returnList = new List<string>();

            //Test           
            returnList.AddRange(InvalidIDReasons());
            returnList.AddRange(InvalidIsPaidReasons());
            returnList.AddRange(InvalidProductsReasons());
            returnList.AddRange(InvalidTransactionsReasons());
            returnList.AddRange(InvalidAmountReasons());

            //Return
            return returnList;
        }

        public bool HasValidID(out List<string> invalidReasons)
        {
            invalidReasons = InvalidIDReasons();
            if (invalidReasons.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> InvalidIDReasons()
        {
            //Init values
            List<string> returnList = new List<string>();

            //Test           
            if (ID < 0)
            {
                returnList.Add("ID may not be null.");             
            }

            //Return
            return returnList;
        }

        public bool HasValidIsPaid(out List<string> invalidReasons)
        {
            invalidReasons = InvalidIsPaidReasons();
            if (invalidReasons.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> InvalidIsPaidReasons()
        {
            //Init values
            List<string> returnList = new List<string>();

            //Test           
            //None so far

            //Return
            return returnList;
        }

        public bool HasValidProducts(out List<string> invalidReasons)
        {
            invalidReasons = InvalidProductsReasons();
            if (invalidReasons.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> InvalidProductsReasons()
        {
            //Init values
            List<string> returnList = new List<string>();

            //Test           
            foreach (Product p in Products) //Test if nested products are valid
            {
                if (p.IsValid(out List<string> invalidReasons))
                {
                    returnList.AddRange(invalidReasons);
                    break;
                }
                
            }

            //Return
            return returnList;
        }

        public bool HasValidTransactions(out List<string> invalidReasons)
        {
            invalidReasons = InvalidTransactionsReasons();
            if (invalidReasons.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> InvalidTransactionsReasons()
        {
            //Init values
            List<string> returnList = new List<string>();

            //Test           
            foreach (Transaction t in Transactions)
            {        
                if (t.IsValid(out List<string> invalidReasons))
                {
                    returnList.AddRange(invalidReasons);
                    break;
                }
            }

            //Return
            return returnList;
        }

        public bool HasValidAmount(out List<string> invalidReasons)
        {
            invalidReasons = InvalidAmountReasons();
            if (invalidReasons.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> InvalidAmountReasons()
        {
            //Init values
            List<string> returnList = new List<string>();

            //Test
            if (Amount < 0)
            {
                returnList.Add("Amount may not be negative.");
            }

            //Return
            return returnList;
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

        public static Basket GetMockBasket(int basketID)
        {
            List<Basket> baskets = GetMockBaskets();
            return baskets[basketID - 1];
        }

        public static List<Basket> GetMockBaskets()
        {
            //Get needed values
            List<Product> mockProducts = Product.GetMockProducts();
            List<Transaction> mockTransactions = Transaction.GetMockTransactions();

            //Init
            List<Basket> baskets = new List<Basket>();

            baskets.Add(new Basket(
                1,
                false,
                new ObservableCollection<Product>
                {
                     mockProducts[0],
                     mockProducts[2]
                },
                new ObservableCollection<Transaction>
                {
                    mockTransactions[1]
                },
                300));

            baskets.Add(new Basket(
                2,
                true,
                new ObservableCollection<Product>
                {
                     mockProducts[1] ,
                     mockProducts[2]
                },
                new ObservableCollection<Transaction>
                {
                    mockTransactions[2]
                },
                300));

            baskets.Add(new Basket(
                3,
                false,
                new ObservableCollection<Product>
                {
                     mockProducts[0]
                },
                new ObservableCollection<Transaction>
                {
                },
                400));

            return baskets;
        }
    }
}
