using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public class HttpUsersService : IHttpUsersService
    {
        public async Task<User> GetUser(string userName)
        {
            //Init values
            User returnValue = new List<Product>();

            //Make call
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:44320/api/Users/" + userName);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<User>();
                    break;
                default:
                    throw new Exception();

            }
            return returnValue;
        }
    }
}
