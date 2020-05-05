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
        public async Task<Product> GetProduct(int productID)
        {
            //Init values
            Product returnValue = null;

            //Make call
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:44320/api/Products/" + productID);
           
            //Process response code
            switch (response.StatusCode)
            {             
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<Product>();
                    break;
                default:
                    throw new Exception();

            }
            return returnValue;
        }

        public async Task<List<Product>> GetProductsOfBasket(int basketID)
        {
            //Init values
            List<Product> returnValue = new List<Product>();

            //Make call
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:44320/api/Products/Baskets/" + basketID);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<List<Product>>();
                    break;
                default:
                    throw new Exception();

            }
            return returnValue;
        }
    }
}
