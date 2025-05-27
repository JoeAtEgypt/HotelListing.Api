using System.ComponentModel.DataAnnotations;

namespace HotelListing.Api.Models.Hotel;

public class CreateHotelDto : BaseHotelDto
{
    [Required]
    public int CountryId { get; set; }
}
