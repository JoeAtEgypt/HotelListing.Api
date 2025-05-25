using System;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Data;

public class HotelListingDBContext : DbContext
{
    public HotelListingDBContext(DbContextOptions<HotelListingDBContext> options) : base(options)
    {
    }

    public DbSet<Country> Countries { get; set; } // DbSet for Country entity that represents a table in the database
    public DbSet<Hotel> Hotels { get; set; }

}
