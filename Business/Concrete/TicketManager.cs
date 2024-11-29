using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TicketManager : ITicketService
    {
        ITicketRepository _ticketRepository;

        public TicketManager(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public void CancelTicket(int ticketId)
        {
            var ticket = _ticketRepository.Get(t=>t.ticket_id==ticketId);
            if (ticket != null)
            {
                ticket.is_cancelled = true;
                _ticketRepository.Update(ticket);
            }
            else
            {
                throw new ArgumentException("Ticket not found");
            }
        }

        public void CreateTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                _ticketRepository.Create(ticket);
            }
            else
            {
                throw new ArgumentNullException(nameof(ticket), "Ticket cannot be null");
            }
        }

        public void DeleteTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                _ticketRepository.Delete(ticket);
            }
            else
            {
                throw new ArgumentNullException(nameof(ticket), "Ticket cannot be null");
            }
        }

        public List<Ticket> GetAllTickets(int id)
        {
            return _ticketRepository.GetAll();
        }

        public Ticket GetTicketById(int id)
        {
            return _ticketRepository.Get(t => t.ticket_id == id);
        }

        public Ticket GetTicketDetails(int ticketId)
        {
            return _ticketRepository.GetTicketDetails(ticketId);
        }

        public List<Ticket> GetTicketsByTripId(int tripId)
        {
            return _ticketRepository.GetTicketsByTripId(tripId);
        }

        public void UpdateTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                _ticketRepository.Update(ticket);
            }
            else
            {
                throw new ArgumentNullException(nameof(ticket), "Ticket cannot be null");
            }
        }
    }
}
