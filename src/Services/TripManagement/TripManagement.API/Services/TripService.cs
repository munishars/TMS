using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripManagement.API.Models;
using TripManagement.API.Repositories;

namespace TripManagement.API.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _repository;

        public TripService(ITripRepository tripRepository)
        {
            _repository = tripRepository;
        }
        public Trip BookTrip(Trip trip)
        {
            return _repository.BookTrip(trip);
        }

        public bool CancelTrip(int tripId, Trip trip)
        {
            return _repository.CancelTrip(tripId,trip);
        }

        public bool ConfirmTrip(int tripId, Trip trip)
        {
            return _repository.ConfirmTrip(tripId, trip); 
        }

        public bool DeleteTrip(int tripId)
        {
            return _repository.DeleteTrip(tripId);
        }

        public List<Trip> GetAllTrips()
        {
            return _repository.GetAllTrips();
        }

        public Trip GetTripById(int tripId)
        {
            return _repository.GetTripById(tripId);
        }

        public List<Trip> GetTripsByCustomerId(int customerId)
        {
            return _repository.GetTripsByCustomerId(customerId);
        }

        public List<Trip> GetTripsByEmployeeId(int employeeId)
        {
            return _repository.GetTripsByEmployeeId(employeeId);
        }
    }
}
