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
        public async Task<Basket> ChangeProductCount(Basket basket, int basketID, int productID, int quantity)
        {
            //Init values
            Basket returnValue = null;

            //Make call
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PutAsJsonAsync("https://localhost:44320/api/Baskets/" + basketID + "/ChangProductCount/" + productID + "/Quantity/" + quantity, basket);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<Basket>();
                    break;
                default:
                    throw new Exception();
            }
            return returnValue;
        }

        public async Task<bool> DeleteBasket(int basketID)
        {
            //Init values
            bool returnValue = false;

            //Make call
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.DeleteAsync("https://localhost:44320/api/Baskets/" + basketID);

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

        public async Task<Basket> GetBasket(int basketID)
        {
            //Init values
            Basket returnValue = null;

            //Make call
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:44320/api/Baskets/" + basketID);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<Basket>();
                    break;
                default:
                    throw new Exception();

            }
            return returnValue;
        }

        public async Task<List<Basket>> GetBasketsOfUser(string userName)
        {
            //Init values
            List<Basket> returnValue = new List<Basket>();

            //Make call
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:44320/api/Baskets/Users/" + userName);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<List<Basket>>();
                    break;
                default:
                    throw new Exception();

            }
            return returnValue;
        }

        public async Task<Basket> PostBasket(Basket basket, string userName)
        {
            //Init values
            Basket returnValue;

            //Make call
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:44320/api/Baskets/Users/" + userName, basket);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<Basket>();
                    break;
                default:
                    throw new Exception();

            }
            return returnValue;
        }

        public async Task<Basket> PutBasket(Basket basket, int basketID)
        {
            //Init values
            Basket returnValue;

            //Make call
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PutAsJsonAsync("https://localhost:44320/api/Baskets/" + basketID, basket);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<Basket>();
                    break;
                default:
                    throw new Exception();
            }
            return returnValue;
        }

        public async Task<Basket> RemoveProductFromBasket(Basket basket, int basketID, int productID)
        {
            //Init values
            Basket returnValue;

            //Make call
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PutAsJsonAsync("https://localhost:44320/api/Baskets/" + basketID + "/RemoveProduct/" + productID, basket);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<Basket>();
                    break;
                default:
                    throw new Exception();
            }
            return returnValue;
        }
    }
}
