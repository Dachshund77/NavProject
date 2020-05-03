using Commons.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Domain
{
    public class Transaction : BaseDomain
    {
        private int id;
        private DateTime timePaid;
        private PaymentType paymentType;
        private double amount;

        public int ID
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }
        public DateTime TimePaid
        {
            get { return TimePaid; }
            set { SetProperty(ref timePaid, value); }
        }
        public PaymentType PaymentType
        {
            get { return paymentType; }
            set { SetProperty(ref paymentType, value); }
        }
        public double Amount
        {
            get { return amount; }
            set { SetProperty(ref amount, value); }
        }

        /// <summary>
        /// Creates a deep copy.
        /// </summary>
        /// <param name="other"></param>
        public Transaction(Transaction other)
        {
            this.ID = other.ID;
            this.TimePaid = other.TimePaid;
            this.PaymentType = other.PaymentType;
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
            returnList.AddRange(InvalidTimePaidReasons());
            returnList.AddRange(InvalidPaymentTypeReasons());
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
                returnList.Add("ID may not be negative.");
                return returnList;
            }

            //Return
            return returnList;
        }

        public bool HasValidTimePaid(out List<string> invalidReasons)
        {
            invalidReasons = InvalidTimePaidReasons();
            if (invalidReasons.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> InvalidTimePaidReasons()
        {
            //Init values
            List<string> returnList = new List<string>();

            //Test
            //Well it is allowed to be nulli guess?

            //Return
            return returnList;
        }

        public bool HasValidPaymentType(out List<string> invalidReasons)
        {
            invalidReasons = InvalidPaymentTypeReasons();
            if (invalidReasons.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> InvalidPaymentTypeReasons()
        {
            //Init values
            List<string> returnList = new List<string>();

            //Test
            //No reason so far


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
                return returnList;
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
            var other = obj as Transaction;
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
            int hash = 179;
            hash = (hash * 19) + ID.GetHashCode();
            return hash;
        }
    }
}
