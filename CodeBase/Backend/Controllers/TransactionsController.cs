using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Interfaces;
using Commons.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    public class TransactionsController : Controller
    {

        private readonly INavTransactionsService navTransactionsService;

        public TransactionsController(INavTransactionsService navTransactionsService)
        {
            this.navTransactionsService = navTransactionsService;
        }

        [HttpPost("/Baskets/{basketID}")]
        public ActionResult<Transaction> PostTransaction(Transaction transaction, int basketID) //TODO need to reference a basket
        {
            //Will probably be handle by navision automaticly in the backend
            //Probably still need that i guess... idk payment is weird since its not propper secured without 3rd party software
            return StatusCode(501);
        }

        [HttpPut("{transactionID}")]
        public ActionResult<Transaction> PutTransaction(Transaction transaction, int transactionID)
        {
            //Should probably no be added
            return StatusCode(501);
        }

        [HttpDelete("{transactionID}")]
        public ActionResult DeleteTransaction(int transactionID)
        {
            //Low priortiy, idk if this even is needed
            return StatusCode(501);
        }

        [HttpGet("{transactionID}")]
        public ActionResult<Transaction> GetTransaction(int transactionID)
        {
            return StatusCode(501); //We will need that, should also fetch realted data i think
        }

        [HttpGet("/Baskets/{basketID}")]
        public ActionResult<List<Transaction>> GetTransactionsOfBasket(int basketID)
        {
            //We will need that, should return all transaction of specifieid oder
            return StatusCode(501);
        }

        [HttpGet("/Users/{userName}")]
        public ActionResult<List<Transaction>> GetTransactionsOfUser(string userName)
        {
            //Makes sense to have that
            return StatusCode(501);
        }
    }
}