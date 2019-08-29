using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.API.Models;

namespace UserManagement.API.DataAccess
{
    public class UserDbContext : DbContext, IUserDbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(m => m.UserId);
            builder.Entity<User>().Property(u => u.UserName).IsRequired();
            builder.Entity<User>().Property(u => u.Password).IsRequired();
            builder.Entity<User>().Property(u => u.FullName).IsRequired();
            builder.Entity<User>().Property(u => u.Contact).IsRequired();
            builder.Entity<User>().Property(u => u.Role).IsRequired();
            builder.Entity<User>().ToTable("Users");
            base.OnModelCreating(builder);
        }
    }
}
