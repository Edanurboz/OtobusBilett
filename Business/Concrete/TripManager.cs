using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TripManager : ITripService
    {
        ITripRepository _tripRepository;

        // Dependency injection ile ITripRepository nesnesini alıyoruz
        public TripManager(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public void Create(Trip trip)
        {
            if (trip != null)
            {
                _tripRepository.Create(trip);
            }
            else
            {
                throw new ArgumentNullException(nameof(trip), "Trip cannot be null");
            }
        }

        public void DeleteTrip(Trip trip)
        {
            if (trip != null)
            {
                _tripRepository.Delete(trip);
            }
            else
            {
                throw new ArgumentNullException(nameof(trip), "Trip cannot be null");
            }
        }

        public List<Trip> GetAllTrips()
        {
            return _tripRepository.GetAll();
        }

        public Trip GetTripById(int id)
        {
            return _tripRepository.Get(tr=>tr.trip_id == id);
        }

        public Trip GetTripDetails(int tripId)
        {
            return _tripRepository.GetTripDetails(tripId);
        }

        public List<Trip> GetTrips(string departureCity, string arrivalCity)
        {
            if (!string.IsNullOrEmpty(departureCity) && !string.IsNullOrEmpty(arrivalCity))
            {
                return _tripRepository.GetTrips(departureCity, arrivalCity);
            }
            else
            {
                throw new ArgumentException("Departure and arrival cities must be specified");
            }
        }

        public void UpdateTrip(Trip trip)
        {
            if (trip != null)
            {
                _tripRepository.Update(trip);
            }
            else
            {
                throw new ArgumentNullException(nameof(trip), "Trip cannot be null");
            }
        }
    }
}
