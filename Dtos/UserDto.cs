using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
    public class UserDto
    {
        
        public int userId { get; set; }
       
        [Required]         
        public string userEmail { get; set; }
       
        [Required]
        public double hardwareId { get; set; }

    //    public string UserPassword{get; set;}


       
    }
}