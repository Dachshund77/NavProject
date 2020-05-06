using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public class HttpProductsService : IHttpProductsService
    {
        public async Task<Product> GetProduct(string barcode, HttpClient httpClient = null)
        {
            //Init values
            Product returnValue = null;
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            //Make call
            string url = "https://localhost:44320/api/Products/" + barcode;
            HttpResponseMessage response = await httpClient.GetAsync(url);
           
            //Process response code
            switch (response.StatusCode)
            {             
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<Product>();
                    break;
                default:
                    throw new Exception("Failed for: " + url);

            }
            return returnValue;
        }

        public async Task<List<Product>> GetProductsOfBasket(int basketID, HttpClient httpClient = null)
        {
            //Init values
            List<Product> returnValue = new List<Product>();
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            //Make call
            string url = "https://localhost:44320/api/Products/Baskets/" + basketID;
            HttpResponseMessage response = await httpClient.GetAsync(url);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<List<Product>>();
                    break;
                default:
                    throw new Exception("Failed for: " + url);

            }
            return returnValue;
        }
    }
}
