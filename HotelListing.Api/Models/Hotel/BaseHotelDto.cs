using System;

namespace HotelListing.Api.Models.Hotel;

public abstract class BaseHotelDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public double Rating { get; set; }
}
