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
    public class ProductsController : Controller
    {
        private readonly INavProductsService navProductsService;

        public ProductsController(INavProductsService navProductsService)
        {
            this.navProductsService = navProductsService;
        }

        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
           /*
            * This endpoint wont be needed
            * Posting a product here would register a new product in the DB aka navision
            * Our Admins will use NAvision directly so kinda pointless
            * A User will never post products.
            */
            return StatusCode(501);
        }

        [HttpPut("{productID}")]
        public ActionResult<Product> PutProduct(Product product, int productID)
        {
            //Same as PostProduct
            return StatusCode(501);
        }

        [HttpDelete("{productID}")]
        public ActionResult DeleteProduct(int productID)
        {
            //Same as PostProduct
            return StatusCode(501);
        }

        [HttpGet("{productID}")]
        public ActionResult<Product> GetProduct(string barcode)
        {
            try
            {
                //Test for null
                if (barcode == null)
                {
                    return BadRequest("JSON Body was Empty!");
                }

                //Retrieve values from Servie
                Product returnProduct = navProductsService.GetProduct(barcode);

                //Return requested ressources
                return Ok(returnProduct);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet("Baskets/{basketID}")]
        public ActionResult<Dictionary<Product, int>> GetProductsOfBasket(int basketID)
        {
            try
            {
                //Test for null
                if (basketID == 0) //Ints default to 0 if not set 
                {
                    return BadRequest("JSON Body was Empty!");
                }

                //Retrieve values from Servie
                List<Product> returnProducts = navProductsService.GetProductsOfBasket(basketID);

                //Return requested ressources
                return Ok(returnProducts);
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