using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IAdminRepository
    {
           Task<Admin> Authenticate(string userName, string password);
    }
}