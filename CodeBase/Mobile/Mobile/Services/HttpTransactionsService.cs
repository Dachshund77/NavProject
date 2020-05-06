using Commons.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public class HttpTransactionsService : IHttpTransactionsService
    {
        public async Task<Transaction> GetTransaction(int transactionID, HttpClient httpClient = null)
        {
            //Init values
            Transaction returnValue = null;
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            //Make call
            string url = "https://localhost:44320/api/Transactions/" + transactionID;
            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:44320/api/Transactions/" + transactionID);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<Transaction>();
                    break;
                default:
                    throw new Exception("Failed for: " + url);

            }
            return returnValue;
        }

        public async Task<List<Transaction>> GetTransactionsOfBasket(int basketID, HttpClient httpClient = null)
        {
            //Init values
            List<Transaction> returnValue = null;
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            //Make call
            string url = "https://localhost:44320/api/Transactions/Baskets/" + basketID;
            HttpResponseMessage response = await httpClient.GetAsync(url);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<List<Transaction>>();
                    break;
                default:
                    throw new Exception("Failed for: " + url);

            }
            return returnValue;
        }

        public async Task<List<Transaction>> GetTransactionsOfUser(string userName, HttpClient httpClient = null)
        {
            //Init values
            List<Transaction> returnValue = null;
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            //Make call
            string url = "https://localhost:44320/api/Transactions/Users/" + userName;
            HttpResponseMessage response = await httpClient.GetAsync(url);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<List<Transaction>>();
                    break;
                default:
                    throw new Exception("Failed for: " + url);

            }
            return returnValue;
        }
    }
}
