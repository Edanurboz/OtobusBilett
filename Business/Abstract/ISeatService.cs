using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISeatService
    {
        //burada istediğini yaz fiyat aralığı vs
        void Create(Seat seat);
        void Update(Seat seat);
        void Delete(Seat seat);
        Seat GetById(int id);
        List<Seat> GetAll();
        List<Seat> GetAvailableSeats(int tripId);
        Seat GetSeatDetails(int seatId);
        void ReserveSeat(int seatId);
        void ReleaseSeat(int seatId);
    }
}
