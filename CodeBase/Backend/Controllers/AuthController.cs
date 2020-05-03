using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commons.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        [HttpPost("/Login")]
        public ActionResult<string> LogIn(User user) //Return a token 
        {        
            return StatusCode(501);
        }

        [HttpPost("/Logout")] //Need to be authorized i thinkh
        public ActionResult LogOut(User user) //idk 
        {
            return StatusCode(501);
        }

        [HttpPost("/Register")] //Need to be authorized i thinkh
        public ActionResult Register(User user) //Should maybe immidieatly return a token, idk about email verification though 
        {
            return StatusCode(501);
        }
    }
}