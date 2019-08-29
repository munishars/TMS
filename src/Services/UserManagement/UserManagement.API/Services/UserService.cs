using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.API.Models;

namespace UserManagement.API.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        public User RegisterUser(User user)
        {
            var result = _repository.RegisterUser(user);
            return (result != null) ? result : null;
        }

        public bool DeleteUser(int userId)
        {
            return _repository.DeleteUser(userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAllUsers();
        }

        public User GetUserById(int vehicleId)
        {
            return _repository.GetUserById(vehicleId);
        }

        public bool UpdateUser(int userId, User user)
        {
            return _repository.UpdateUser(userId, user);
        }
    }
}
