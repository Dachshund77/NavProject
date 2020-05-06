using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Interfaces;
using Commons.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class BasketsController : Controller
    {
        private readonly INavBasketsService navBasketsService;

        public BasketsController(INavBasketsService navBasketsService)
        {
            this.navBasketsService = navBasketsService;
        }

        [HttpPost("Users/{userName}")] //Needs reference to the realted user
        public ActionResult<Basket> PostBasket(Basket basket, string userName)
        {
            try
            {
                //Test for null calls
                if (userName == null)
                {
                    return BadRequest("JSON Body was Empty!");
                }

                //Test for wellfomred JSON
                if (!basket.IsValid(out List<string> invalidReasons))
                {
                    string message = invalidReasons.First();
                    return BadRequest(message);
                }

                //Retrieve values from Servie
                Basket returnBasket = navBasketsService.PostBasket(basket, userName);

                //Test if value was found
                if (returnBasket == null)
                {
                    return NotFound("Basket does not exist!");
                }

                //Return requested ressources
                return StatusCode(201, returnBasket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPut("{basketID}")]
        public ActionResult<Basket> PutBasket(Basket basket, int basketID)
        {
            try
            {
                //Test for null calls
                if (basketID == 0) //Ints default to 0 if not set 
                {
                    return BadRequest("JSON Body was Empty!");
                }

                //Test for wellfomred JSON
                if (!basket.IsValid(out List<string> invalidReasons))
                {
                    string message = invalidReasons.First();
                    return BadRequest(message);
                }

                //Retrieve values from Servie
                Basket returnBasket = navBasketsService.PutBasket(basket, basketID);

                //Test if value was found
                if (returnBasket == null)
                {
                    return NotFound("Basket does not exist!");
                }

                //Return requested ressources
                return Ok(returnBasket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPut("{basketID}/ChangProductCount/{productID}/Quantity/{quantity}")]  //I dont think we need the basket here... ?
        public ActionResult<Basket> ChangeProductCount(Basket basket, int basketID, int productID, int quantity)
        {
            try
            {
                //Test for null calls
                if (basketID == 0) //Ints default to 0 if not set 
                {
                    return BadRequest("BasketID was Empty!");
                }
                if (productID == 0)
                {
                    return BadRequest("ProductID was Empty!");
                }
                if (quantity == 0)
                {
                    return BadRequest("Quantity may not be 0!");
                }

                //Test for wellfomred JSON
                if (!basket.IsValid(out List<string> invalidReasons))
                {
                    string message = invalidReasons.First();
                    return BadRequest(message);
                }

                //Retrieve values from Servie
                Basket returnBasket = navBasketsService.ChangeProductCount(basket, basketID, productID, quantity);

                //Test if value was found
                if (returnBasket == null)
                {
                    return NotFound("Basket does not exist!");
                }

                //Return requested ressources
                return Ok(returnBasket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPut("{basketID}/RemoveProduct/{barcode}")]
        public ActionResult<Basket> RemoveProductFromBasket(Basket basket, int basketID, string barcode)
        {
            try
            {
                //Test for null calls
                if (basketID == 0) //Ints default to 0 if not set 
                {
                    return BadRequest("BasketID was Empty!");
                }
                if (barcode.Equals(null))
                {
                    return BadRequest("ProductID was Empty!");
                }               

                //Test for wellfomred JSON
                if (!basket.IsValid(out List<string> invalidReasons))
                {
                    string message = invalidReasons.First();
                    return BadRequest(message);
                }

                //Retrieve values from Servie
                Basket returnBasket = navBasketsService.RemoveProductFromBasket(basket, basketID, barcode);

                //Test if value was found
                if (returnBasket == null)
                {
                    return NotFound("Basket does not exist!");
                }

                //Return requested ressources
                return Ok(returnBasket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpDelete("{basketID}")]
        public ActionResult DeleteBasket(int basketID)
        {
            try
            {
                //Test for null calls
                if (basketID == 0) //Ints default to 0 if not set 
                {
                    return BadRequest("BasketID was Empty!");
                }             

                //Retrieve values from Servie
                navBasketsService.DeleteBasket(basketID);           

                //Return requested ressources
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet("{basketID}")]
        public ActionResult<Basket> GetBasket(int basketID)
        {
            try
            {
                //Test for null
                if (basketID == 0) //Ints default to 0 if not set 
                {
                    return BadRequest("JSON Body was Empty!");
                }

                //Retrieve values from Servie
                Basket returnBasket = navBasketsService.GetBasket(basketID);

                //Return requested ressources
                return Ok(returnBasket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet("Users/{userName}")]
        public ActionResult<List<Basket>> GetBasketsOfUser(string userName)
        {
            try
            {
                //Test for null
                if (userName == null) 
                {
                    return BadRequest("JSON Body was Empty!");
                }

                //Retrieve values from Servie
                List<Basket> returnBaskets = navBasketsService.GetBasketsOfUser(userName);

                //Return requested ressources
                return Ok(returnBaskets);
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