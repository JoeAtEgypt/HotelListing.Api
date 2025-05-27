using HotelListing.Api.Data;

namespace HotelListing.Api.Contract;

public interface ICountriesRepository : IGenericRepository<Country>
{
    // Additional methods specific to countries can be defined here
    public Task<Country> GetDetails(int? id);
}
