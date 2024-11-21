using InternetProvider.Application.DTOs.AuthDTOs;
using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;

namespace InternetProvider.Application.Mappers;

public static class ClientMapper
{
    public static ClientResponseDto ToClientResponseDto(this ClientOutput oth)
    {
        return new ClientResponseDto()
        {
            Id = oth.Id,
            ClientStatusName = oth.ClientStatusName,
            LocationTypeName = oth.LocationTypeName,
            CityName = oth.CityName,
            StreetName = oth.StreetName,
            HouseNumber = oth.HouseNumber,
            ApartmentNumber = oth.ApartmentNumber,
            FirstName = oth.FirstName,
            LastName = oth.LastName,
            PhoneNumber = oth.PhoneNumber,
            Email = oth.Email,
            RegistrationDate = oth.RegistrationDate,
        };
    }
    
    public static ClientInput ToDomainClientInput(this ClientRequestDto oth)
    {
        return new ClientInput()
        {
            ClientStatusId = oth.ClientStatusId,
            LocationId = oth.LocationId,
            FirstName = oth.FirstName,
            LastName = oth.LastName,
            PhoneNumber = oth.PhoneNumber,
            Email = oth.Email,
        };
    }
    
    public static ClientInput ToDomainClientInput(this RegisterClientRequestDto oth, string userId)
    {
        return new ClientInput()
        {
            ClientStatusId = oth.ClientStatusId,
            LocationId = oth.LocationId,
            UserId = userId,
            FirstName = oth.FirstName,
            LastName = oth.LastName,
            PhoneNumber = oth.PhoneNumber,
            Email = oth.Email,
        };
    }
}