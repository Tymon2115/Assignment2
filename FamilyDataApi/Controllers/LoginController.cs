using System;
using System.Threading.Tasks;
using AdultDataAPI.Data;
using AdultDataAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdultDataAPI.Controllers {
    public class LoginController : ControllerBase {
        private IUserService userService;

        public LoginController(IUserService userService) {
            this.userService = userService;
        }

        [Route("/Login/UserLogin")]
        [HttpPost]
        public async Task<ActionResult<User>> Login([FromBody] User user) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try {
                var validatedUser = await userService.ValidateUser(user.UserName, user.Password);

                return Ok(validatedUser);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }
    }
}