using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dc;

        public UserRepository(DataContext dc)
    {
            this.dc = dc;
        }
           public void AddUser(User user)
        {
            dc.Users.Add(user);             
        }

        public void DeleteUser(int userId)
        {
            var user = dc.Users.Find(userId);
            dc.Users.Remove(user);
        }

        public async Task<User> FindUser(int id)
        {
            return await dc.Users.FindAsync(id);
         }  

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await dc.Users.ToListAsync();
        }
        // public async Task<User> Authenticate(string userEmail, double hardwareId)
        // {
        //    return await dc.Users.FirstOrDefaultAsync(x => x.userEmail == userEmail
        //    && x.hardwareId == hardwareId);
        //  }

        // public async Task<User> Authenticate(string userEmail, string UserPassword)
        // {
        //    return await dc.Users.FirstOrDefaultAsync(x => x.userEmail == userEmail
        //    && x.UserPassword == UserPassword);
        // }
    } 
}