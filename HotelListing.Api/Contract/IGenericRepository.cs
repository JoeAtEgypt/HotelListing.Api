using System;

namespace HotelListing.Api.Contract;

public interface IGenericRepository<T>
    where T : class
{
    Task<IList<T>> GetAllAsync();
    Task<T> GetAsync(int? id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
