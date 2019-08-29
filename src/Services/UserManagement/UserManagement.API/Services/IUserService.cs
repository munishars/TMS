using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.API.Models;

namespace UserManagement.API.Services
{
    public interface IUserService
    {
        User RegisterUser(User user);
        bool UpdateUser(int userId, User user);
        bool DeleteUser(int userId);
        User GetUserById(int userId);
        IEnumerable<User> GetAllUsers();

    }
}
