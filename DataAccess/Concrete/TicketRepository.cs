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
    public class TicketRepository :EfEntityRepositoryBase<Ticket, BiletOtomasyonu>, ITicketRepository
    
    {
        private readonly BiletOtomasyonu _context;

        public TicketRepository(BiletOtomasyonu context)
        {
            _context = context;
        }

        public void CancelTicket(int ticketId)
        {
            var ticket = _context.Tickets.Find(ticketId);
            if (ticket != null)
            {
                ticket.is_cancelled = true; 
                _context.SaveChanges();
            }
        }


        public Ticket GetTicketDetails(int ticketId)
        {
            return _context.Tickets
                           .Include(t => t.Trip)         
                           .Include(t => t.User)     
                           .FirstOrDefault(t => t.ticket_id == ticketId);
        }

        public List<Ticket> GetTicketsByTripId(int tripId)
        {
            return _context.Tickets
                           .Where(t => t.trip_id == tripId)
                           .ToList();
        }

      
    }
}
