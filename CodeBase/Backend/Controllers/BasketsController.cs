using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commons.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    //[Authorize]
    [ApiController]
    public class BasketsController : Controller
    {
        [HttpPost("/Users/{userName}")] //Needs reference to the realted user
        public ActionResult<Basket> PostBasket(Basket basket, string userName)
        {     
            //Will probabl need that when initalising a basket
            return StatusCode(501);
        }

        [HttpPut("{basketID}")]
        public ActionResult<Basket> PutBasket(Basket basket, int basketID)
        {
            //Will need that, for bulk update
            return StatusCode(501);
        }

        [HttpPut("{basketID}/AddProduct/{productID}/Quantity/{quantity}")] 
        public ActionResult<Basket> AddProductToBasket(Basket basket, int basketID, int productID, int quantity)
        {
            //Will probabl need that when initalising a basket
            return StatusCode(501);
        }

        [HttpPost("/AddProduct/{productID}/Quantity/{quantity}")] 
        public ActionResult<Basket> RemoveProductFromBasket(Basket basket, int basketID, int productID, int quantity)
        {
            //Will probabl need that when initalising a basket
            return StatusCode(501);
        }

        [HttpDelete("{basketID}")]
        public ActionResult DeleteBasket(int basketID)
        {
            //Maybe if that is even allowed... maybe for unpaid ones. 
            return StatusCode(501);
        }

        [HttpGet("{basketID}")]
        public ActionResult<Basket> GetBasket(int basketID)
        {
            return StatusCode(501); //Will need that 
        }

        [HttpGet("/Users/{userName}")]
        public ActionResult<List<Basket>> GetBasketsOfUser(string userName)
        {
            return StatusCode(501); //Will need that 
        }
    }
}