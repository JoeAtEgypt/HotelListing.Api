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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Country>().HasData(
            new Country { CountryId = 1, Name = "USA", ShortName = "US" },
            new Country { CountryId = 2, Name = "Canada", ShortName = "CA" }
        );

        modelBuilder.Entity<Hotel>().HasData(
            new Hotel { Id = 1, Name = "Hotel California", Address = "123 Sunset Blvd", CountryId = 1 , Rating = 4.5 },
            new Hotel { Id = 2, Name = "Maple Leaf Inn", Address = "456 Maple St", CountryId = 2, Rating = 4.0 },   
            new Hotel { Id = 3, Name = "Grand Hotel", Address = "789 Grand Ave", CountryId = 1, Rating = 5.0 }
        );
    }

}
