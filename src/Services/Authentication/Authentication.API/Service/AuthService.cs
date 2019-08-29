using Authentication.API.Models;
using Authentication.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Authentication.API.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository repository;

        public AuthService(IAuthRepository _repository)
        {
            this.repository = _repository;
        }
        public User LoginUser(string userId, string password)
        {
            var validUser = repository.LoginUser(userId, password);
            return validUser;
        }
        public bool RegisterUser(User user)
        {
            var result = repository.RegisterUser(user);
            return result;
        }
        public User FindUserById(string userId)
        {
            var validUser = repository.FindUserById(userId);
            return validUser;
        }
    }
}
