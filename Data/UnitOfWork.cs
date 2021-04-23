using System.Threading.Tasks;
using Backend.Data.Repo;
using Backend.Interfaces;

namespace Backend.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;

        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }
        public IUserRepository UserRepository => new UserRepository(dc);

        public IAdminRepository AdminRepository => 
        new AdminRepository(dc);
        

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;   
        }
    }
}