using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Roxa.BLL;
using Roxa.DAL;
using Roxa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roxa.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserCrudService _userCrudInterface;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserController(
            IUserCrudService userCrudInterface,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            SignInManager<User> signInManager
            )
        {
            _userCrudInterface = userCrudInterface;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpPost, Route("login")]
        public async Task<ActionResult> Login([FromBody]LoginModelBll userLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.UserName == userLogin.UserName);
                return Ok(new { Token = _userCrudInterface.GenerateJwtToken(userLogin.UserName, appUser) });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("Register")]
        public async Task<ActionResult> Register([FromBody]LoginModelBll loginModel)
        {
            var user = new User
            {
                UserName = loginModel.UserName               
            };
            var role = new Role
            {
                Name = loginModel.Role
            };

            var result = await _userManager.CreateAsync(user, loginModel.Password);
            var resultdwa = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Ok(new { Token = _userCrudInterface.GenerateJwtToken(loginModel.UserName, user) });
            }

            return Unauthorized();
        }


        [HttpGet, Route("GetList")]
        public async Task<ActionResult> GetList()
        {
            IList<UserBll> userBll = await _userCrudInterface.GetLists();

            return Ok(userBll);
        }


        //[HttpGet]
        //public UserBll GetUserById(long id)
        //{
        //    return _userCrudInterface.GetUserById();
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
