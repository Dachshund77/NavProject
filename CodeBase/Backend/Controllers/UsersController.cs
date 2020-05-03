using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commons.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    //[Authorize]
    [ApiController]
    public class UsersController : Controller
    {
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            //Will probably not be implemented, as adding new users will be handeled via registration.
            return StatusCode(501);
        }

        [HttpPut("{userName}")]
        public ActionResult<User> PutUser(User user, string userName)
        {
            //Updating of user values should follow strict rules, like we lets a user overwrite the passowrd
            //Probabl will not make the cut
            return StatusCode(501);
        }

        [HttpDelete("{userName}")]
        public ActionResult DeleteUser(string userName)
        {
            //Low priortiy, if a user want to dele himself?
            return StatusCode(501);
        }

        [HttpGet("{userName}")]
        public ActionResult<User> GetUser(string userName)
        {
            return StatusCode(501); //We will need that, should also fetch realted data i think
        }
    }
}