using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Api.Data;

public class Hotel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Address { get; set; }
    public double Rating { get; set; }

    // Navigation property to the Country entity
    [ForeignKey(nameof(CountryId))]
    public int CountryId { get; set; } // Foreign key
    public Country? Country { get; set; } // Navigation property
}



