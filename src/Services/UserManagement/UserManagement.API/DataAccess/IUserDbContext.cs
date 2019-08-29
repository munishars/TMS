using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.API.Models;

namespace UserManagement.API.DataAccess
{
    public interface IUserDbContext
    {
        DbSet<User> Users { get; }
        int SaveChanges();
    }
}
