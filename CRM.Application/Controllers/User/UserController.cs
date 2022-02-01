using CRM.Application.Models.User;
using CRM.Application.Repository.Interface.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CRM.Application.Controllers.User
{
   
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;


        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

      

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(UserViewModel usersdata)
        {
            var token = _userRepository.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

    }
}
