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
        public bool IsValid(out IEnumerable<string> invalidReasons)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> InvalidReasons()
        {
            throw new NotImplementedException();
        }

        public bool IsValidPassword(out IEnumerable<string> invalidReasons)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> InvalidPasswordReasons()
        {
            throw new NotImplementedException();
        }

        public bool IsValidEmail(out IEnumerable<string> invalidReasons)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> InvalidEmailReasons()
        {
            throw new NotImplementedException();
        }

        public bool IsValidBaskets(out IEnumerable<string> invalidReasons)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> InvalidBasketsReasons()
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
