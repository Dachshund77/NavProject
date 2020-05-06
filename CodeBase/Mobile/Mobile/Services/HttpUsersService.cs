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
        public async Task<User> GetUser(string userName, HttpClient httpClient = null)
        {
            //Init values
            User returnValue = null;
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            //Make call
            string url = "https://localhost:44320/api/Users/" + userName;
            HttpResponseMessage response = await httpClient.GetAsync(url);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<User>();
                    break;
                default:
                    throw new Exception("Failed for: " + url);

            }
            return returnValue;
        }
    }
}
