using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}   
    
    
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins {get; set;}
     
    
    
    }
}