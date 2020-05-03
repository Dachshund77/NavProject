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

        public bool IsValidTimePaid(out IEnumerable<string> invalidReasons)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> InvalidTimePaidReasons()
        {
            throw new NotImplementedException();
        }

        public bool IsValidPaymentType(out IEnumerable<string> invalidReasons)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> InvalidPaymentTypeReasons()
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
