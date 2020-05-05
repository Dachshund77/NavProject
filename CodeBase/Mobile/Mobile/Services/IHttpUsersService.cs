using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Services
{
    public interface IHttpUsersService
    {
        User GetUser(string userName);
    }
}
