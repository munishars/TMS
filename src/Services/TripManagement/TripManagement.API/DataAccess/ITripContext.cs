using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripManagement.API.Models;

namespace TripManagement.API.DataAccess
{
    public interface ITripContext
    {
        DbSet<Trip> Trips { get; }
        int SaveChanges();
    }
}
