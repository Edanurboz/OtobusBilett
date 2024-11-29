using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public IActionResult GetAllTickets(int id)
        {
            var tickets = _ticketService.GetAllTickets(id);
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public IActionResult GetTicketById(int id)
        {
            var ticket = _ticketService.GetTicketById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpPost]
        public IActionResult CreateTicket([FromBody] Ticket ticket)
        {
            _ticketService.CreateTicket(ticket);
            return CreatedAtAction(nameof(GetTicketById), new { id = ticket.ticket_id }, ticket);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTicket(int id, [FromBody] Ticket ticket)
        {
            if (id != ticket.ticket_id)
            {
                return BadRequest();
            }

            _ticketService.UpdateTicket(ticket);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTicket(int id)
        {
            var ticket = _ticketService.GetTicketById(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _ticketService.DeleteTicket(ticket);
            return NoContent();
        }
    }
}