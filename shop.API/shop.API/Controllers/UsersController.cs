using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using shop.API.Models;
using shop.API.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public IActionResult Login(UserLoginModel userLogin)
        {
            var user = userService.Validate(userLogin.Email, userLogin.Password);
            if (user != null)
            {
                var claims = new[]
                {
                   new Claim(JwtRegisteredClaimNames.Email,user.Email),
                   new Claim(JwtRegisteredClaimNames.UniqueName, user.LastName+" "+user.Name)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Eşsiz bir cümle..."));
                var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: "info.sofftech.com",
                    audience: "info.sofftech.com",
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddDays(3),
                    signingCredentials: credential);

                return Ok(new { token =new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return BadRequest(new { message = "Kullanıcı adı ya da şifre hatalı" });
        }
    }
}
