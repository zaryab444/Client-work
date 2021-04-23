using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IUserRepository
    {
          Task<IEnumerable<User>> GetUsersAsync();

          void AddUser( User user );

          void DeleteUser(int userId);

          Task<User> FindUser(int id);
   

    }
}