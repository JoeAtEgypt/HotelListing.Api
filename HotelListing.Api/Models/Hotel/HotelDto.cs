using System;
using HotelListing.Api.Models.Country;

namespace HotelListing.Api.Models.Hotel;

public class HotelDto : BaseHotelDto
{
    public GetCountryDto Country { get; set; }
}
