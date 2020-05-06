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
        public async Task<string> LogIn(User user, HttpClient httpClient = null)
        {
            //Init values
            string returnValue = null;
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            //Make call
            string url = "https://localhost:44320/api/Auth/Login";
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, user);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsStringAsync();
                    break;
                default:
                    throw new Exception("Failed for: " + url);

            }
            return returnValue;
        }

        public async Task<bool> LogOut(User user, HttpClient httpClient = null)
        {
            //Init values
            bool returnValue = false;
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            //Make call
            string url = "https://localhost:44320/api/Auth/Logout";
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, user);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = true;
                    break;
                default:
                    throw new Exception("Failed for: " + url);

            }
            return returnValue;
        }

        public async Task<bool> Register(User user, HttpClient httpClient = null)
        {
            //Init values
            bool returnValue = false;
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            //Make call
            string url = "https://localhost:44320/api/Auth/Register";
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, user);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = true;
                    break;
                default:
                    throw new Exception("Failed for: " + url);

            }
            return returnValue;
        }
    }
}
