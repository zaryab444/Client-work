using AutoMapper;
using Backend.Dtos;
using Backend.Models;

namespace Backend.Helpers
{
    public class AutoMapperProfiles : Profile
    {
          public AutoMapperProfiles(){
              CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();

          }
    } 
}