using System;
using HotelListing.Api.Contract;
using HotelListing.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Repository;

public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
{
    private readonly HotelListingDBContext _context;

    public CountriesRepository(HotelListingDBContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<Country> GetDetails(int? id)
    {
        var country = await _context
            .Countries.Include(q => q.Hotels)
            .FirstOrDefaultAsync(q => q.CountryId == id);
        return country;
    }
}
