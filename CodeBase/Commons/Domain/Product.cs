using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Domain
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string BarCode { get; set; } //TODO: Barcode implementation might change

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

            if(this.ID != other.ID)
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
