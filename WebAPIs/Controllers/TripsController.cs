
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        ITripService _tripService;

        public TripsController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet]
        public IActionResult GetAllTrips()
        {
            var trips = _tripService.GetAllTrips();
            return Ok(trips);
        }

        [HttpGet("{id}")]
        public IActionResult GetTripById(int id)
        {
            var trip = _tripService.GetTripById(id);
            if (trip == null)
            {
                return NotFound();
            }
            return Ok(trip);
        }

        [HttpPost]
        public IActionResult CreateTrip([FromBody] Trip trip)
        {
            _tripService.Create(trip);
            return CreatedAtAction(nameof(GetTripById), new { id = trip.trip_id }, trip);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTrip(int id, [FromBody] Trip trip)
        {
            if (id != trip.trip_id)
            {
                return BadRequest();
            }

            _tripService.UpdateTrip(trip);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTrip(int id)
        {
            var trip = _tripService.GetTripById(id);
            if (trip == null)
            {
                return NotFound();
            }

            _tripService.DeleteTrip(trip);
            return NoContent();
        }
    }
}




