using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Commons.Domain
{
    public class User : BaseDomain
    {
        private string userName;
        //private string plainPassword;
        private string email;
        private ObservableCollection<Basket> baskets;

        public string UserName
        {
            get { return userName; }
            set { SetProperty(ref userName, value); }
        }
        public string PlainPassword { get; set; }
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }
        public ObservableCollection<Basket> Baskets
        {
            get { return baskets; }
            set { SetProperty(ref baskets, value); }
        }

        public User()
        {
            Baskets = new ObservableCollection<Basket>();
        }

        /// <summary>
        /// Create a deep clone.
        /// </summary>
        /// <param name="other"></param>
        public User(User other)
            : this()
        {
            this.UserName = other.UserName;
            this.Email = other.Email;
            //Deep cloning baskets
            foreach (Basket b in Baskets)
            {
                this.Baskets.Add(new Basket(b));
            }
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
            returnList.AddRange(InvalidUserNameReasons());
            returnList.AddRange(InvalidPasswordReasons());
            returnList.AddRange(InvalidEmailReasons());
            returnList.AddRange(InvalidBasketsReasons());

            //Return
            return returnList;
        }

        public bool HasValidUserName(out List<string> invalidReasons)
        {
            invalidReasons = InvalidUserNameReasons();
            if (invalidReasons.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> InvalidUserNameReasons()
        {
            //Init values
            List<string> returnList = new List<string>();

            //Test
            if (PlainPassword == null)
            {
                returnList.Add("UserName may not be negative.");
                return returnList;
            }
            if (PlainPassword.Length < 6)
            {
                returnList.Add("Password must be at least 6 letters long.");
            }
            if (PlainPassword.Length > 50)
            {
                returnList.Add("Password must be less 50 or less charakters.");
            }

            //Return
            return returnList;
        }

        public bool HasValidPassword(out List<string> invalidReasons)
        {
            invalidReasons = InvalidPasswordReasons();
            if (invalidReasons.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> InvalidPasswordReasons()
        {
            //Init values
            List<string> returnList = new List<string>();

            //Test
            if (PlainPassword == null)
            {
                returnList.Add("Password may not be negative.");
                return returnList;
            }
            if (PlainPassword.Length < 6)
            {
                returnList.Add("Password must be at least 6 letters long.");
            }
            if (PlainPassword.Length > 50)
            {
                returnList.Add("Password must be less 50 or less charakters.");
            }

            //Return
            return returnList;
        }

        public bool HasValidEmail(out List<string> invalidReasons)
        {
            invalidReasons = InvalidEmailReasons();
            if (invalidReasons.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> InvalidEmailReasons()
        {
            //Init values
            List<string> returnList = new List<string>();

            //Test
            if (Email == null)
            {
                returnList.Add("Email may not be negative.");
                return returnList;
            }
            if (!Email.Contains("@"))
            {
                returnList.Add("Email must contain @.");
            }

            //Return
            return returnList;
        }

        public bool HasValidBaskets(out List<string> invalidReasons)
        {
            invalidReasons = InvalidBasketsReasons();
            if (invalidReasons.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<string> InvalidBasketsReasons()
        {
            //Init values
            List<string> returnList = new List<string>();

            //Test           
            foreach (Basket b in Baskets)
            {
                if (b.IsValid(out List<string> invalidReasons))
                {
                    returnList.AddRange(invalidReasons);
                    break;
                }
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
            var other = obj as User;
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

            if (this.UserName != other.UserName)
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
            int hash = 23;
            hash = (hash * 199) + UserName.GetHashCode();
            return hash;
        }
    }
}
