using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Admin
    {
        public int AdminId{get; set;}

       [Required]
       public string Username{get; set;}

       [Required]

       public string Password{get; set;}
    }
}