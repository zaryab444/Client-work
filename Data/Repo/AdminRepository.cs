using System.Threading.Tasks;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Repo
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext dc;
        public AdminRepository(DataContext dc)
        {
            this.dc = dc;

        }
        public async Task<Admin> Authenticate(string userName, string password)
        {
           return await dc.Admins.FirstOrDefaultAsync(x => x.Username == userName
           && x.Password == password);
         }
    }
}