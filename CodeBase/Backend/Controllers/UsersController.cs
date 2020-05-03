using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Interfaces;
using Commons.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    //[Authorize]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly INavUsersService navUsersService;

        public UsersController(INavUsersService navUsersService)
        {
            this.navUsersService = navUsersService;
        }

        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            /*
             * A user will register itself via the AuthController,
             * This is because there are certain formalities that need to be fulfilled
             * This endpoint would be an admin way to cirumvent this
             * But our admins will likely use navision directly
             */
            return StatusCode(501);
        }

        [HttpPut("{userName}")]
        public ActionResult<User> PutUser(User user, string userName)
        {
            /*
             * Will not be implemented, same reason as PostUser endpoint
             */
            return StatusCode(501);
        }

        [HttpDelete("{userName}")]
        public ActionResult DeleteUser(string userName)
        {
            /*
             * Will nit be implemented, same reason as PostUser endpooint
             */
            return StatusCode(501);
        }

        //TODO: Need authentication, authorisation.
        [HttpGet("{userName}")]
        public ActionResult<User> GetUser(string userName)
        {
            try
            {
                //Test for null
                if(userName == null)
                {
                    return BadRequest("JSON Body was Empty!");
                }

                //Retrieve values from Servie
                User returnUser = navUsersService.GetUser(userName);

                //Return requested ressources
                return Ok(returnUser);
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