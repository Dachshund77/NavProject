
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
        private Dictionary<Product, int> products; //Freaking c# Does not have an observableDictornary. If needed write own or find 3rd party online.
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
        public Dictionary<Product, int> Products
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
                
                Products = new Dictionary<Product, int>();
            }
            if (Transactions == null)
            {
                Transactions = new ObservableCollection<Transaction>();
            }
        }

        public Basket(int id, bool isPaid, Dictionary<Product,int> products, ObservableCollection<Transaction> transactions, double amount)
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
            foreach (KeyValuePair<Product,int> entry in other.Products)
            {
                this.Products.Add(entry.Key, entry.Value);
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
            foreach (KeyValuePair<Product, int> entry in Products) //Test if nested products are valid
            {
                if (entry.Key.IsValid(out List<string> invalidReasons))
                {
                    returnList.AddRange(invalidReasons);
                    break;
                }
                //Product may not be empty
                if(entry.Value <= 0)
                {
                    returnList.Add(entry.Key+": may not have value of 0.");
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
    }
}
