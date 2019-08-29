using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.API.DataAccess;
using UserManagement.API.Models;
using UserManagement.API.Services;

namespace UserManagement.API.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IUserDbContext _context;

        public UserRepository(IUserDbContext dbContext)
        {
            _context = dbContext;
        }
        public User RegisterUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                int result = _context.SaveChanges();
                return (result > 0) ? user : null;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
        public bool DeleteUser(int userId)
        {
            var vehicle = GetUserById(userId);
            _context.Users.Remove(vehicle);
            int result = _context.SaveChanges();
            return (result > 0);
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.AsEnumerable();
        }
        public User GetUserById(int userId)
        {
            return _context.Users.Where(x => x.UserId == userId).FirstOrDefault();
        }
        public bool UpdateUser(int userId, User user)
        {
            int result = 0;
            var existing = GetUserById(userId);
            if (existing != null)
            {
                _context.Users.Update(user);
                result = _context.SaveChanges();
            }
            return (result > 0);
        }
    }
}
