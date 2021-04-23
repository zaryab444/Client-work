using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Backend.Dtos;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IConfiguration configuration;
        public AdminController(IUnitOfWork uow, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.uow = uow;

        }
        //api/admin/login

        [HttpPost("login")]

       // http://localhost:5000/api/admin/login
        public async Task<IActionResult> Login(LoginReqDto loginReq)
        {
            var admin = await uow.AdminRepository.Authenticate(loginReq.UserName, loginReq.Password);
            if (admin == null)
            {
                return Unauthorized();
            }
            var loginRes = new LoginResDto();
            loginRes.UserName = admin.Username;
            loginRes.Token = CreateJWT(admin);
            return Ok(loginRes);
        }
        private string CreateJWT(Admin admin)
        {
             var secretKey = configuration.GetSection("AppSettings:Key").Value;
            
              var key = new SymmetricSecurityKey(Encoding.UTF8
              .GetBytes(secretKey));

            var claims = new Claim[]{
                  new Claim(ClaimTypes.Name, admin.Username),
                  new Claim(ClaimTypes.NameIdentifier, admin.AdminId.ToString())
              };
            var signingCredentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);



        }

    }
}