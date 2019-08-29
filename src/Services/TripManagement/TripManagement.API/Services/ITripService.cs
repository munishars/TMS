using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripManagement.API.Models;

namespace TripManagement.API.Services
{
    public interface ITripService
    {
        Trip BookTrip(Trip trip);
        bool ConfirmTrip(int tripId, Trip trip);
        bool CancelTrip(int tripId, Trip trip);
        bool DeleteTrip(int tripId);
        Trip GetTripById(int tripId);
        List<Trip> GetAllTrips();
        List<Trip> GetTripsByCustomerId(int customerId);
        List<Trip> GetTripsByEmployeeId(int employeeId);
    }
}
