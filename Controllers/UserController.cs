using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AndroidApi.Domain.DTO_s;
using AndroidApi.Domain.IRepositories;
using AndroidApi.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AndroidApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class UserController : ControllerBase
    {
        private readonly ITaskTeamRepository _taskTeams;
        private readonly IUserRepository _users;
        private readonly ITaskRepository _tasks;

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;


        public UserController(IUserRepository users,
            ITaskTeamRepository taskTeams,
            ITaskRepository tasks, 
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IConfiguration config)
        {
            _taskTeams = taskTeams;
            _users = users;
            _tasks = tasks;
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
        }
        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="email">the email of the user</param>
        /// <param name="password">the password of the user</param>
        /// <returns>The logged in user</returns>
        [HttpGet("login/{email}/{password}")]
        public async Task<ActionResult<UserDTO>> LoginUser(string email, string password)
        {
            var iuser = await _userManager.FindByNameAsync(email);
            if (iuser == null)
            {
                return BadRequest();
            }
            var result = await _signInManager.CheckPasswordSignInAsync(iuser, password, false);

            if (result.Succeeded)
            {

                return new UserDTO(_users.GetUserByMail(email));
            }
            return BadRequest();

        }
    }
}