using HotelListing.Api.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelListing.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelsController : ControllerBase
{
    private static readonly List<Hotel> hotels = new List<Hotel>
    {
        new Hotel
        {
            Id = 1,
            Name = "Hotel California",
            Address = "123 Sunset Blvd, Los Angeles, CA",
            Rating = 4.5
        },
        new Hotel
        {
            Id = 2,
            Name = "The Grand Budapest Hotel",
            Address = "456 Alpine Road, Zubrowka",
            Rating = 4.8
        },
        new Hotel
        {
            Id = 3,
            Name = "The Shining Hotel",
            Address = "789 Mountain Drive, Colorado",
            Rating = 4.2
        }
    };
    
    // GET: api/Hotels
    [HttpGet]
    public ActionResult<IEnumerable<Hotel>> Get()
    {
        return Ok(hotels);
    }

    // GET: api/Hotels/5
    [HttpGet("{id}")]
    public ActionResult<Hotel> Get(int id)
    {
        var hotel = hotels.FirstOrDefault(h => h.Id == id);
        if (hotel == null)
        {
            return NotFound();
        }
        
        return Ok(hotel);
    }

    // POST: api/Hotels
    [HttpPost] 
    public ActionResult<Hotel> Create([FromBody] Hotel hotel)
    {
        if (hotels.Any(h => h.Id == hotel.Id))
        {
            return BadRequest("Hotel with the same ID already exists.");
        }
        hotels.Add(hotel);
        return CreatedAtAction(nameof(Get), new { id = hotel.Id }, hotel);
    }

    // PUT: api/Hotels/5
    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] Hotel hotel)
    {
        var existingHotel = hotels.FirstOrDefault(h => h.Id == id);
        if (existingHotel == null)
        {
            return NotFound();
        }        
        existingHotel.Name = hotel.Name;
        existingHotel.Address = hotel.Address;
        existingHotel.Rating = hotel.Rating;
        return Ok(existingHotel);
    }

    // DELETE: api/Hotels/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var hotel = hotels.FirstOrDefault(h => h.Id == id);
        if (hotel == null)
        {
            return NotFound(new { Message = "Hotel not found." });
        }
        hotels.Remove(hotel);
        return NoContent();
    }
}
