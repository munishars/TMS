using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripManagement.API.DataAccess;
using TripManagement.API.Models;

namespace TripManagement.API.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly ITripContext _context;

        public TripRepository(ITripContext dbContext)
        {
            _context = dbContext;
        }
        public Trip BookTrip(Trip trip)
        {
            try
            {
                _context.Trips.Add(trip);
                int result = _context.SaveChanges();
                return (result > 0) ? trip : null;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
        public bool CancelTrip(int tripId, Trip trip)
        {
            int result = 0;
            var existing = GetTripById(tripId);
            if (existing != null)
            {
                _context.Trips.Update(trip);
                result = _context.SaveChanges();
            }
            return (result > 0);
        }

        public bool ConfirmTrip(int tripId, Trip trip)
        {
            int result = 0;
            var existing = GetTripById(tripId);
            if (existing != null)
            {
                _context.Trips.Update(trip);
                result = _context.SaveChanges();
            }
            return true;
        }

        public bool DeleteTrip(int tripId)
        {
            var vehicle = GetTripById(tripId);
            _context.Trips.Remove(vehicle);
            int result = _context.SaveChanges();
            return (result > 0);
        }

        public List<Trip> GetAllTrips()
        {
            return _context.Trips.ToList();
        }

        public Trip GetTripById(int tripId)
        {
            return _context.Trips.Where(x => x.TripId == tripId).FirstOrDefault();
        }

        public List<Trip> GetTripsByCustomerId(int customerId)
        {
            return _context.Trips.Where(x => x.CustomerId == customerId).ToList();
        }

        public List<Trip> GetTripsByEmployeeId(int employeeId)
        {
            return _context.Trips.Where(x => x.EmployeeId == employeeId).ToList();
        }
    }
}
