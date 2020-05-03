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
            //Probably wont be needed
            //Its for posting a new product
            return StatusCode(501);
        }

        [HttpPut("{productID}")]
        public ActionResult<Product> PutProduct(Product product, int productID)
        {
            //Probably wont be added, since the adding updating of product will be direct in navision...
            return StatusCode(501);
        }

        [HttpDelete("{productID}")]
        public ActionResult DeleteProduct(int productID)
        {
            //no need as its done in navision directly
            return StatusCode(501);
        }

        [HttpGet("{productID}")]
        public ActionResult<Product> GetProduct(int productID)
        {
            return StatusCode(501); //We will need that
        }

        [HttpGet("Baskets/{basketID}")]
        public ActionResult<List<Product>> GetProductsOfBasket(int basketID)
        {
            return StatusCode(501); //We will need that, fetches all products of basket
        }
    }
}