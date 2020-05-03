using Backend.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Commons.Domain
{
    public class Product : BaseDomain
    {

        private int id;
        private string name;
        private string description;
        private double price;
        private int quantity;
        private string barcode;

        public int ID
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }
        public double Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
        public string BarCode  //TODO: Barcode implementation might change
        {
            get { return barcode; }
            set { SetProperty(ref barcode, value); }
        }

        /// <summary>
        /// Copy Constructor, creates deep copy.
        /// </summary>
        /// <param name="other"></param>
        public Product(Product other)
        {
            this.ID = other.ID;
            this.Name = other.Name;
            this.Description = other.Description;
            this.Price = other.Price;
            this.Quantity = other.Quantity;
            this.BarCode = other.BarCode;
        }

        public bool IsValid(out IEnumerable<string> invalidReasons)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> InvalidReasons()
        {
            throw new NotImplementedException();
        }

        public bool IsValidID(out IEnumerable<string> invalidReason)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> InvalidIDReasons()
        {
            throw new NotImplementedException();
        }

        public bool IsValidDescription(out IEnumerable<string> invalidReasons)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> InvalidDescriptionReasons()
        {
            throw new NotImplementedException();
        }

        public bool IsValidPrice(out IEnumerable<string> invalidReasons)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> InvalidPriceReasons()
        {
            throw new NotImplementedException();
        }

        public bool IsValidQuantity(out IEnumerable<string> invalidReasons)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> InvalidQuantityReasons()
        {
            throw new NotImplementedException();
        }

        public bool IsValidBarCode(out IEnumerable<string> invalidReason)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> InvalidBarcodeReasons()
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
            var other = obj as Product;
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
            int hash = 17;
            hash = (hash * 7) + ID.GetHashCode();
            return hash;
        }

    }
}
