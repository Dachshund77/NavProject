
using System;
using System.Collections.Generic;
using System.Linq;

namespace Commons.Domain
{
    public class Product : BaseDomain
    {

        private string barcode;
        private string name;
        private string description;
        private double price;
        private int amount;

        public string Barcode
        {
            get { return barcode; }
            set { SetProperty(ref barcode, value); }
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

        public Product() { }

        public Product(string barcode, string name, string description, double price, int amount)          
        {
            Barcode = barcode;
            Name = name;
            Description = description;
            Price = price;
            Amount = amount;           
        }

        /// <summary>
        /// Copy Constructor, creates deep copy.
        /// </summary>
        /// <param name="other"></param>
        public Product(Product other)
        {
            this.Barcode = other.Barcode;
            this.Name = other.Name;
            this.Description = other.Description;
            this.Price = other.Price;
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
            returnList.AddRange(InvalidBarcodeReasons());
            returnList.AddRange(InvalidNameReasons());
            returnList.AddRange(InvalidDescriptionReasons());
            returnList.AddRange(InvalidPriceReasons());
           

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
            if (Barcode == null)
            {
                returnList.Add("Barcode may not be null.");
                return returnList;
            }

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

            if (!this.Barcode.Equals(other.Barcode))
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
            hash = (hash * 7) + Barcode.GetHashCode();
            return hash;
        }

        public static Product GetMockProduct(string barcode)
        {
            try
            {
                List<Product> products = GetMockProducts();
                return products.Where(x => x.Barcode.Equals(barcode)).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw; //We just want the error log here
            }        
        }

        public static List<Product> GetMockProducts()
        {
            try
            {
                List<Product> products = new List<Product>();
                products.Add(new Product("fasdfsadfasf", "Apple", "Green Apple", 5.99, 4));
                products.Add(new Product("fasdfgsdnhrasfassadfasf", "Bannana", "Blue Bananan", 8.99, 5));
                products.Add(new Product("afafukghkgsfa", "Cat", "Red Care", 566.99, 2));

                return products;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw; //We just want the error log here
            }          
        }
    }
}
