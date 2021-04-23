using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
// using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Controllers;
using Backend.Data;
using Backend.Dtos;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Admin_User_Application.Controllers
{
 

      [Authorize]
    public class UserController : BaseController
    {
        
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        private readonly IConfiguration configuration;

        public UserController( IUnitOfWork uow , IMapper mapper, IConfiguration configuration)
        {    
            this.configuration = configuration;
             this.uow = uow;
            this.mapper = mapper;
        }



        [HttpGet("")]
        [AllowAnonymous]
    
   // http://localhost:5000/api/user/
        public async Task<IActionResult> GetUsers()
        {


           var users = await uow.UserRepository.GetUsersAsync();
           var usersDto = mapper.Map<IEnumerable<UserDto>>(users);
         

            return Ok(usersDto);

        }

  
      
        
        [HttpPost("post")]

         //   http://localhost:5000/api/user/post
        public async Task<IActionResult> AddUsers(UserDto userDto)
        {
            var user = mapper.Map<User>(userDto);
             uow.UserRepository.AddUser(user);
            await uow.SaveAsync();
            return StatusCode(200);
        }


      

      [HttpPut("update/{id}")]

       // http://localhost:5000/api/user/update/id
      public async Task<IActionResult> UpdateCity(int id, UserDto userDto){
           
           
           if(id !=userDto.userId)
           return BadRequest("Update not allowed");
           var userFromDb = await uow.UserRepository.FindUser(id);
           mapper.Map(userDto, userFromDb);
           await uow.SaveAsync();
           return StatusCode(200);


      }

   


        [HttpDelete("delete/{id}")]

        //http://localhost:5000/api/user/delete/id
        public async Task<IActionResult> DeleteUser(int id)
        {
            uow.UserRepository.DeleteUser(id);
            await uow.SaveAsync();
            return Ok(id);
        }
 




    }
}
