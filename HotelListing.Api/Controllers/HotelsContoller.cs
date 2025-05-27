using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HotelListing.Api.Contract;
using HotelListing.Api.Data;
using HotelListing.Api.Models.Hotel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelsRepository _hotelsRepository;
        private readonly IMapper _mapper;

        public HotelsController(IMapper mapper, IHotelsRepository hotelsRepository)
        {
            _hotelsRepository = hotelsRepository;
            _mapper = mapper;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetHotelDto>>> GetHotels()
        {
            var hotels = await _hotelsRepository.GetAllAsync();
            var records = _mapper.Map<List<GetHotelDto>>(hotels);
            return Ok(records);
        }

        // GET: api/Hotels/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> GetHotel(int id)
        {
            var hotel = await _hotelsRepository.GetDetails(id);

            if (hotel == null)
            {
                return NotFound();
            }
            var record = _mapper.Map<HotelDto>(hotel);
            return Ok(record);
        }

        // POST: api/Hotels
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(CreateHotelDto createHotel)
        {
            var hotel = _mapper.Map<Hotel>(createHotel);
            await _hotelsRepository.AddAsync(hotel);
            return CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotel);
        }

        // PUT: api/Hotels/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, UpdateHotelDto updateHotel)
        {
            if (id != updateHotel.Id)
            {
                return BadRequest("Record Invalid Id");
            }

            var hotel = await _hotelsRepository.GetAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            _mapper.Map(updateHotel, hotel);

            try
            {
                await _hotelsRepository.UpdateAsync(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Hotels/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel(int id)
        {
            var hotel = await _hotelsRepository.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            await _hotelsRepository.DeleteAsync(id);

            return Ok(hotel);
        }

        private async Task<bool> HotelExists(int id)
        {
            return await _hotelsRepository.ExistsAsync(id);
        }
    }
}
