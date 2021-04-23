using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository   UserRepository{get;}

        IAdminRepository AdminRepository{get;}
        Task<bool> SaveAsync();
    }
}