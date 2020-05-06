using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public class HttpBasketsService : IHttpBasketsService
    {
        public async Task<Basket> ChangeProductCount(Basket basket, int basketID, int productID, int quantity, HttpClient httpClient = null)
        {
            //Init values
            Basket returnValue = null;
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            //Make call
            string url = "https://localhost:44320/api/Baskets/" + basketID + "/ChangProductCount/" + productID + "/Quantity/" + quantity;
            HttpResponseMessage response = await httpClient.PutAsJsonAsync(url, basket);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<Basket>();
                    break;
                default:
                    throw new Exception("Failed for: " + url);
            }
            return returnValue;
        }

        public async Task<bool> DeleteBasket(int basketID, HttpClient httpClient = null)
        {
            //Init values
            bool returnValue = false;
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            //Make call
            string url = "https://localhost:44320/api/Baskets/" + basketID;
            HttpResponseMessage response = await httpClient.DeleteAsync(url);

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

        public async Task<Basket> GetBasket(int basketID, HttpClient httpClient = null)
        {
            //Init values
            Basket returnValue = null;
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            //Make call
            string url = "https://localhost:44320/api/Baskets/" + basketID;
            HttpResponseMessage response = await httpClient.GetAsync(url);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<Basket>();
                    break;
                default:
                    throw new Exception("Failed for: " + url);

            }
            return returnValue;
        }

        public async Task<List<Basket>> GetBasketsOfUser(string userName, HttpClient httpClient = null)
        {
            //Init values
            List<Basket> returnValue = new List<Basket>();
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            //Make call
            string url = "https://localhost:44320/api/Baskets/Users/" + userName;
            HttpResponseMessage response = await httpClient.GetAsync(url);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<List<Basket>>();
                    break;
                default:
                    throw new Exception("Failed for: " + url);

            }
            return returnValue;
        }

        public async Task<Basket> PostBasket(Basket basket, string userName, HttpClient httpClient = null)
        {
            //Init values
            Basket returnValue;
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            //Make call
            string url = "https://localhost:44320/api/Baskets/Users/" + userName;
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(url, basket);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.Created:
                    returnValue = await response.Content.ReadAsAsync<Basket>();
                    break;
                default:
                    throw new Exception("Failed for: " + url);

            }
            return returnValue;
        }

        public async Task<Basket> PutBasket(Basket basket, int basketID, HttpClient httpClient = null)
        {
            //Init values
            Basket returnValue;
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            //Make call
            string url = "https://localhost:44320/api/Baskets/" + basketID;
            HttpResponseMessage response = await httpClient.PutAsJsonAsync(url, basket);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<Basket>();
                    break;
                default:
                    throw new Exception("Failed for: " + url);
            }
            return returnValue;
        }

        public async Task<Basket> RemoveProductFromBasket(Basket basket, int basketID, string barcode, HttpClient httpClient = null)
        {
            //Init values
            Basket returnValue;
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            //Make call
            string url = "https://localhost:44320/api/Baskets/" + basketID + "/RemoveProduct/" + barcode;
            HttpResponseMessage response = await httpClient.PutAsJsonAsync(url, basket);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<Basket>();
                    break;
                default:
                    throw new Exception("Failed for: " + url);
            }
            return returnValue;
        }
    }
}
