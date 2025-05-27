using HotelListing.Api.Models.Hotel;

namespace HotelListing.Api.Models.Country;

public class CountryDto : GetCountryDto
{
        public virtual IList<HotelDto> Hotels { get; set; }
}
