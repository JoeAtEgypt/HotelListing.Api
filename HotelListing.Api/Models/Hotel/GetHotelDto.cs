using HotelListing.Api.Models.Country;

namespace HotelListing.Api.Models.Hotel;

public class GetHotelDto : BaseHotelDto
{
    public int CountryId { get; set; }
}
