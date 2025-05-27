namespace HotelListing.Api.Models.Hotel;

public class UpdateHotelDto : BaseHotelDto
{
    public int Id { get; set; }
    public int CountryId { get; set; }
}
