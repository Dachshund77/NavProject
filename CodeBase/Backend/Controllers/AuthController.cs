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
    public class AuthController : Controller
    {
        private readonly INavAuthService navAuthService;

        public AuthController(INavAuthService navAuthService)
        {
            this.navAuthService = navAuthService;
        }

        [HttpPost("/Login")]
        public ActionResult<string> LogIn(User user) //Return a token 
        {
            try
            {
                //Test for null calls
                if (user == null)
                {
                    return BadRequest("JSON Body was Empty!");
                }

                //Test for wellfomred JSON
                if (!user.IsValid(out List<string> invalidReasons))
                {
                    string message = invalidReasons.First();
                    return BadRequest(message);
                }

                //Retrieve values from Servie
                string token = navAuthService.LogIn(user);

                //Test if not found
                if(token == null)
                {
                    return NotFound(user);
                }            

                //Return requested ressources
                return Ok(token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPost("/Logout")] //Need to be authorized i thinkh
        public ActionResult LogOut(User user) //idk 
        {
            try
            {
                //Test for null calls
                if (user == null)
                {
                    return BadRequest("JSON Body was Empty!");
                }

                //Test for wellfomred JSON
                if (!user.IsValid(out List<string> invalidReasons))
                {
                    string message = invalidReasons.First();
                    return BadRequest(message);
                }

                //Retrieve values from Servie
                navAuthService.LogOut(user);             

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

        [HttpPost("/Register")] //Need to be authorized i thinkh
        public ActionResult Register(User user) //Should maybe immidieatly return a token, idk about email verification though 
        {
            try
            {
                //Test for null calls
                if (user == null)
                {
                    return BadRequest("JSON Body was Empty!");
                }

                //Test for wellfomred JSON
                if (!user.IsValid(out List<string> invalidReasons))
                {
                    string message = invalidReasons.First();
                    return BadRequest(message);
                }

                //Retrieve values from Servie
                navAuthService.Register(user);

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
    }
}