using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
            if (Baskets == null) //Makes sure list is initalised
            {
                Baskets = new ObservableCollection<Basket>();
            }
        }

        public User(string userName, string plainPassword, string email, ObservableCollection<Basket> baskets)
            : this()
        {
            UserName = userName;
            PlainPassword = plainPassword;
            Email = email;
            Baskets = baskets;
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
                returnList.Add("Password may not be null.");
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
                returnList.Add("Email may not be null.");
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

        public static User GetMockUser(string userName)
        {
            try
            {
                List<User> users = GetMockUsers();
                return users.Where(x => x.UserName == userName).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw; //We just want the error log here
            }
        }

        public static List<User> GetMockUsers()
        {
            try
            {
                //init              
                List<User> mockUser = new List<User>();

                //Build
                mockUser.Add(new User(
                    "Peter",
                    "13sfsaf34",
                    "xas@google.com",
                    new ObservableCollection<Basket>
                    {
                    Basket.GetMockBasket(1),
                   Basket.GetMockBasket(3)
                    }));

                mockUser.Add(new User(
                    "Sven",
                    "133224",
                    "xasffas@google.com",
                    new ObservableCollection<Basket>
                    {
                   Basket.GetMockBasket(2)
                    }));

                mockUser.Add(new User(
                    "Franz",
                    "2fxafxaf221",
                    "Fraaaa@google.com",
                    new ObservableCollection<Basket>
                    {
                    }));

                //return
                return mockUser;
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
