using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using Business.Abstract;
using Entities.Concrete;




namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private ISeatService _seatService;

        public SeatsController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet("GetAllSeats")]
        public IActionResult GetAllSeats()
        {
            var seats = _seatService.GetAll();
            return Ok(seats);
        }

        [HttpGet("GetSeatById")]
        public IActionResult GetSeatById(int id)
        {
            var seat = _seatService.GetById(id);
            if (seat == null)
            {
                return NotFound();
            }
            return Ok(seat);
        }

        [HttpPost("CreateSeat")]
        public IActionResult CreateSeat([FromBody] Seat seat)
        {
            _seatService.Create(seat);
            return CreatedAtAction(nameof(GetSeatById), new { id = seat.seat_id }, seat);
        }

        [HttpPut("UpdateSeat")]
        public IActionResult UpdateSeat(int id, [FromBody] Seat seat)
        {
            if (id != seat.seat_id)
            {
                return BadRequest();
            }

            _seatService.Update(seat);
            return NoContent();
        }

        [HttpDelete("DeleteSeat")]
        public IActionResult DeleteSeat(int id)
        {
            var seat = _seatService.GetById(id);
            if (seat == null)
            {
                return NotFound();
            }

            _seatService.Delete(seat);
            return NoContent();
        }

        [HttpPost("ReserveSeat")]
        public IActionResult ReserveSeat(int seatId)
        {
            _seatService.ReserveSeat(seatId);
            return NoContent();
        }

        [HttpPost("ReleaseSeat")]
        public IActionResult ReleaseSeat(int seatId)
        {
            _seatService.ReleaseSeat(seatId);
            return NoContent();
        }
    }
}

