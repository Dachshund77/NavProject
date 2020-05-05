
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Commons.Domain
{
    public class Product : BaseDomain
    {

        private int id;
        private string name;
        private string description;
        private double price;
        private int amount;
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
        public int Amount
        {
            get { return amount; }
            set { SetProperty(ref amount, value); }
        }
        public string BarCode  //TODO: Barcode implementation might change
        {
            get { return barcode; }
            set { SetProperty(ref barcode, value); }
        }

        public Product(int id, string name, string description, double price, int amount,string barcode)
        {
            ID = id;
            Name = name;
            Description = description;
            Price = price;
            Amount = amount;
            BarCode = barcode;
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
            this.BarCode = other.BarCode;
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
            returnList.AddRange(InvalidNameReasons());
            returnList.AddRange(InvalidDescriptionReasons());
            returnList.AddRange(InvalidPriceReasons());
            returnList.AddRange(InvalidBarcodeReasons());

            //Return
            return returnList;
        }

        public bool HasValidName(out List<string> invalidReasons)
        {
            invalidReasons = InvalidNameReasons();
            if (invalidReasons.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> InvalidNameReasons()
        {
            //Init values
            List<string> returnList = new List<string>();

            //Test           
            if (Name == null)
            {
                returnList.Add("Name may not be null.");
                return returnList;
            }           

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

        public bool HasValidDescription(out List<string> invalidReasons)
        {
            invalidReasons = InvalidDescriptionReasons();
            if (invalidReasons.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> InvalidDescriptionReasons()
        {
            //Init values
            List<string> returnList = new List<string>();

            //Test           
            if (Description == null)
            {
                returnList.Add("Description may not be null.");
                return returnList;
            }

            //Return
            return returnList;
        }

        public bool HasValidPrice(out List<string> invalidReasons)
        {
            invalidReasons = InvalidPriceReasons();
            if (invalidReasons.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> InvalidPriceReasons()
        {
            //Init values
            List<string> returnList = new List<string>();

            //Test
            if (Price < 0)
            {
                returnList.Add("Price may not be negative.");
                return returnList;
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
                return returnList;
            }

            //Return
            return returnList;
        }

        public bool HasValidBarCode(out List<string> invalidReasons)
        {
            invalidReasons = InvalidBarcodeReasons();
            if (invalidReasons.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> InvalidBarcodeReasons()
        {
            //Init values
            List<string> returnList = new List<string>();

            //Test           
            if (BarCode == null)
            {
                returnList.Add("Barcode may not be null.");
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
