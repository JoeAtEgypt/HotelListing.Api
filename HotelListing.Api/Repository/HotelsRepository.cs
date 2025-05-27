using HotelListing.Api.Contract;
using HotelListing.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Repository;

public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
{
    private readonly HotelListingDBContext _context;

    public HotelsRepository(HotelListingDBContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<Hotel> GetDetails(int? id)
    {
        var hotel = await _context
            .Hotels.Include(q => q.Country)
            .FirstOrDefaultAsync(q => q.Id == id);
        return hotel;
    }
}
