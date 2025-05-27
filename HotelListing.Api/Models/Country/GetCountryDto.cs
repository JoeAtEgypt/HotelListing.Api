using System;
using HotelListing.Api.Data;

namespace HotelListing.Api.Models.Country;

public class GetCountryDto : BaseCountryDto
{
    public int CountryId { get; set; }
    
}
