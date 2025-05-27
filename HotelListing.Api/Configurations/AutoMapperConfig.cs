using System;
using AutoMapper;
using HotelListing.Api.Data;
using HotelListing.Api.Models.Country;
using HotelListing.Api.Models.Hotel;

namespace HotelListing.Api.Configurations;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Country, CreateCountryDto>()
            .ReverseMap(); // Maps CreateCountryDto to Country and vice versa
        CreateMap<Country, UpdateCountryDto>()
            .ReverseMap(); // Maps UpdateCountryDto to Country and vice versa
        CreateMap<Country, GetCountryDto>()
            .ReverseMap(); // Maps GetCountryDto to Country and vice versa
        CreateMap<Country, CountryDto>()
            .ReverseMap(); // Maps CountryDto to Country and vice versa
        
        CreateMap<Hotel, HotelDto>()
            .ReverseMap(); // Maps GetHotelDto to Hotel and vice versa
    }
}
