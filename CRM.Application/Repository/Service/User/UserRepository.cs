using CRM.Application.CustomerDbContext;
using CRM.Application.Models.User;
using CRM.Application.Repository.Interface.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Repository.Service.User
{
    public class UserRepository : IUserRepository
    {

        private readonly CustomerContext customerContext;
        private readonly IConfiguration iconfiguration;

 //       Dictionary<string, string> UsersRecords = new Dictionary<string, string>
	//{
	//	{ "user1","password1"},
	//	{ "user2","password2"},
	//	{ "user3","password3"},
	//};

        public UserRepository(CustomerContext _customerContext, IConfiguration _iconfiguration)
        {
            this.customerContext = _customerContext;
            this.iconfiguration = _iconfiguration;
        }

        public Tokens Authenticate(UserViewModel users)
        {

            if (!customerContext.Users.Any(x => x.UserName == users.UserName && x.Password == users.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, users.UserName)
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };

        }

        public Task<UserViewModel> UserLogin(string username, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
