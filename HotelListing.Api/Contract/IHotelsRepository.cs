using HotelListing.Api.Data;

namespace HotelListing.Api.Contract;

public interface IHotelsRepository : IGenericRepository<Hotel>
{
    // Additional methods specific to hotels can be defined here
    public Task<Hotel> GetDetails(int? id);
}
