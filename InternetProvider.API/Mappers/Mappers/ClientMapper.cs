using InternetProvider.Abstraction.Entities;
using InternetProvider.API.DTOs.AuthDTOs;
using InternetProvider.API.DTOs.RequestDTOs;
using InternetProvider.API.DTOs.ResponseDTOs;
using InternetProvider.API.Mappers.Interfaces;

namespace InternetProvider.API.Mappers.Mappers;


public class ClientMapper(IClient client) : IMapper<IClient, ClientRequestDto, ClientResponseDto>, IUserMapper<IClient, RegisterClientRequestDto>
{
    public ClientResponseDto ToResponseDto(IClient oth)
    {
        return new ClientResponseDto()
        {
            Id = oth.ClientId,
            ClientStatusId = oth.ClientStatusId,
            ClientStatusName = oth.ClientStatus.ClientStatusName,
            LocationId = oth.LocationId,
            LocationTypeName = oth.Location.LocationType.LocationTypeName,
            CityName = oth.Location.House.Street.City.CityName,
            StreetName = oth.Location.House.Street.StreetName,
            HouseNumber = oth.Location.House.HouseNumber,
            ApartmentNumber = oth.Location.ApartmentNumber,
            FirstName = oth.FirstName,
            LastName = oth.LastName,
            PhoneNumber = oth.PhoneNumber,
            Email = oth.Email,
            RegistrationDate = oth.RegistrationDate,
        };
    }

    public IClient ToEntity(ClientRequestDto oth)
    {
        client.ClientStatusId = oth.ClientStatusId;
        client.LocationId = oth.LocationId;
        client.FirstName = oth.FirstName;
        client.LastName = oth.LastName;
        client.PhoneNumber = oth.PhoneNumber;
        client.Email = oth.Email;
        return client;
    }

    public IClient ToEntity(RegisterClientRequestDto regDto, string userId)
    {
        client.ClientStatusId = regDto.ClientStatusId;
        client.LocationId = regDto.LocationId;
        client.FirstName = regDto.FirstName;
        client.LastName = regDto.LastName;
        client.PhoneNumber = regDto.PhoneNumber;
        client.Email = regDto.Email;
        client.UserId = userId;
        
        return client;
    }
}