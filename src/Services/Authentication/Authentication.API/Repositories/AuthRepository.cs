using Authentication.API.DataAccess;
using Authentication.API.Models;
using System.Linq;

namespace Authentication.API.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IAuthenticationContext context;
        public AuthRepository(IAuthenticationContext authenticationContext)
        {
            context = authenticationContext;
        }

        public User FindUserById(string userName)
        {
            return context.Users.Where(u => u.UserName == userName).FirstOrDefault();
        }

        public User LoginUser(string userName, string password)
        {
            return context.Users.Where(u => u.UserName == userName && u.Password == password).FirstOrDefault();
        }

        public bool RegisterUser(User user)
        {
            var checkUser = FindUserById(user.UserName);
            if(checkUser!=null)
            {
                return false;
            }

            context.Users.Add(user);
            int result = context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
