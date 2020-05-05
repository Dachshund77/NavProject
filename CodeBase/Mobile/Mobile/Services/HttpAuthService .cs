using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public class HttpAuthService : IHttpAuthService
    {
        public async Task<string> LogIn(User user)
        {
            //Init values
            string returnValue = null;

            //Make call
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:44320/api/Auth/Login", user);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<string>();
                    break;
                default:
                    throw new Exception();

            }
            return returnValue;
        }

        public async Task<bool> LogOut(User user)
        {
            //Init values
            bool returnValue = false;

            //Make call
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:44320/api/Auth/Logout", user);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = true;
                    break;
                default:
                    throw new Exception();

            }
            return returnValue;
        }

        public async Task<bool> Register(User user)
        {
            //Init values
            bool returnValue = false;

            //Make call
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:44320/api/Auth/Register", user);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = true;
                    break;
                default:
                    throw new Exception();

            }
            return returnValue;
        }
    }
}
