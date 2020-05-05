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
        public async Task<Transaction> GetTransaction(int transactionID)
        {
            //Init values
            Transaction returnValue = null;

            //Make call
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:44320/api/Transactions/" + transactionID);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<Transaction>();
                    break;
                default:
                    throw new Exception();

            }
            return returnValue;
        }

        public async Task<List<Transaction>> GetTransactionsOfBasket(int basketID)
        {
            //Init values
            List<Transaction> returnValue = null;

            //Make call
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:44320/api/Transactions/Baskets" + basketID);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<List<Transaction>>();
                    break;
                default:
                    throw new Exception();

            }
            return returnValue;
        }

        public async Task<List<Transaction>> GetTransactionsOfUser(string userName)
        {
            //Init values
            List<Transaction> returnValue = null;

            //Make call
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:44320/api/Transactions/USers" + userName);

            //Process response code
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    returnValue = await response.Content.ReadAsAsync<List<Transaction>>();
                    break;
                default:
                    throw new Exception();

            }
            return returnValue;
        }
    }
}
