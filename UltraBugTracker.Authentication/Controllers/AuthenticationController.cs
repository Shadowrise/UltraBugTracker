using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UltraBugTracker.Authentication.Data;
using UltraBugTracker.Common.Authentication.Models;

namespace UltraBugTracker.Authentication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AuthenticationDbContext _context;

        public AuthenticationController(AuthenticationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Route("users")]
        public async Task<ActionResult<User[]>> GetAsync()
        {
            var users = await _context.Users.AsNoTracking().ToArrayAsync();
            return Ok(users);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] AuthenticationData data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User() {UserName = data.UserName};
            var result = await _userManager.CreateAsync(user, data.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }

            await _signInManager.SignInAsync(user, true);
            return Ok();

        }

        [HttpPost]      
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] AuthenticationData data)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _signInManager.PasswordSignInAsync(data.UserName, data.Password, data.RememberMe, false);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            return Ok();
        }

        [HttpPost]
        [Route("logoff")]
        public async Task<IActionResult> LogoffAsync()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
