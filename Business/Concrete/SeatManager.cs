using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Business.Concrete
{
    public class SeatManager : ISeatService
    {
        ISeatRepository _seatRepository;

        public SeatManager(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public void Create(Seat seat)
        {
            if (seat != null)
            {
                _seatRepository.Create(seat);
            }
            else
            {
                throw new ArgumentNullException(nameof(seat), "Seat cannot be null");
            }
        }

 

        public void Delete(Seat seat)
        {
            if (seat != null)
            {
                _seatRepository.Delete(seat);
            }
            else
            {
                throw new ArgumentNullException(nameof(seat), "Seat cannot be null");
            }
        }


        public List<Seat> GetAll()
        {
            //iş kodları
            return _seatRepository.GetAll();
        }


        public List<Seat> GetAvailableSeats(int tripId)
        {
            if (tripId > 0)
            {
                return _seatRepository.GetAvailableSeats(tripId);
            }
            else
            {
                throw new ArgumentException("Trip ID must be greater than zero");
            }
        }

        public Seat GetById(int id)
        {
            return _seatRepository.Get(s => s.seat_id == id);
        }

        public Seat GetSeatDetails(int seatId)
        {
            return _seatRepository.GetSeatDetails(seatId);
        }

        public void ReleaseSeat(int seatId)
        {
            var seat = _seatRepository.Get(s=>s.seat_id == seatId);
            if (seat != null)
            {
                seat.is_reserved = false;
                _seatRepository.Update(seat);
            }
            else
            {
                throw new ArgumentException("Seat not found");
            }
        }

        public void ReserveSeat(int seatId)
        {
            var seat = _seatRepository.Get(s => s.seat_id == seatId);
            if (seat != null)
            {
                seat.is_reserved = true;
                _seatRepository.Update(seat);
            }
            else
            {
                throw new ArgumentException("Seat not found");
            }
        }

        public void Update(Seat seat)
        {
            if (seat != null)
            {
                _seatRepository.Update(seat);
            }
            else
            {
                throw new ArgumentNullException(nameof(seat), "Seat cannot be null");
            }
        }
    }
}
