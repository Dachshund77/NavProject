using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Interfaces;
using Commons.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TransactionsController : Controller
    {

        private readonly INavTransactionsService navTransactionsService;

        public TransactionsController(INavTransactionsService navTransactionsService)
        {
            this.navTransactionsService = navTransactionsService;
        }

        [HttpPost("/Baskets/{basketID}")]
        public ActionResult<Transaction> PostTransaction(Transaction transaction, int basketID)
        {
            /*
             *  Not need since thiswil lbe handeld by navision and not by our clients.
             */
            return StatusCode(501);
        }

        [HttpPut("{transactionID}")]
        public ActionResult<Transaction> PutTransaction(Transaction transaction, int transactionID)
        {
            //Same reason then PostTransaction endpoint
            return StatusCode(501);
        }

        [HttpDelete("{transactionID}")]
        public ActionResult DeleteTransaction(int transactionID)
        {
            //Same rasons as PostTransaction
            return StatusCode(501);
        }

        [HttpGet("{transactionID}")]
        public ActionResult<Transaction> GetTransaction(int transactionID)
        {
            try
            {
                //Test for null
                if (transactionID == 0) //Ints default to 0 if not set 
                {
                    return BadRequest("JSON Body was Empty!");
                }

                //Retrieve values from Servie
                Transaction returnTransaction = navTransactionsService.GetTransaction(transactionID);

                //Return requested ressources
                return Ok(returnTransaction);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet("/Baskets/{basketID}")]
        public ActionResult<List<Transaction>> GetTransactionsOfBasket(int basketID)
        {
            try
            {
                //Test for null
                if (basketID == 0) //Ints default to 0 if not set 
                {
                    return BadRequest("JSON Body was Empty!");
                }

                //Retrieve values from Servie
                List<Transaction> returnTransactions = navTransactionsService.GetTransactionsOfBasket(basketID);

                //Return requested ressources
                return Ok(returnTransactions);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet("/Users/{userName}")]
        public ActionResult<List<Transaction>> GetTransactionsOfUser(string userName)
        {
            try
            {
                //Test for null
                if (userName == null) 
                {
                    return BadRequest("JSON Body was Empty!");
                }

                //Retrieve values from Servie
                List<Transaction> returnTransactions = navTransactionsService.GetTransactionsOfUser(userName);

                //Return requested ressources
                return Ok(returnTransactions);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}