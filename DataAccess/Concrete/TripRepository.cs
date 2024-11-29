using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class TripRepository : EfEntityRepositoryBase<Trip, BiletOtomasyonu>, ITripRepository
    
    {
        private readonly BiletOtomasyonu _context;

        public TripRepository(BiletOtomasyonu context)
        {
            _context = context;
        }

        public Trip GetTripDetails(int tripId)
        {
            return _context.Trips
                           .Include(t => t.Seats) // Seferle ilişkili koltuk bilgilerini dahil et
                           .FirstOrDefault(t => t.trip_id == tripId);
        }

        public List<Trip> GetTrips(string departureCity, string arrivalCity)
        {
            return _context.Trips
                           .Where(t => t.departure_city == departureCity && t.arrival_city == arrivalCity)
                           .ToList();
        }
    }
}