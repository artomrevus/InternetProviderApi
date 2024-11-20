using InternetProvider.Domain.Entities;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Domain.Mappers;

public static class ClientMappers
{
    public static ClientOutput ToDomainClientOutput(this Client oth)
    {
        return new ClientOutput()
        {
            Id = oth.ClientId,
            ClientStatusName = oth.ClientStatus.ClientStatusName,
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
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
    
    public static Client ToInfrastructureClient(this ClientInput oth)
    {
        return new Client()
        {
            ClientStatusId = oth.ClientStatusId,
            LocationId = oth.LocationId,
            UserId = oth.UserId,
            FirstName = oth.FirstName,
            LastName = oth.LastName,
            PhoneNumber = oth.PhoneNumber,
            Email = oth.Email,
            RegistrationDate = oth.RegistrationDate,
            CreateDateTime = oth.CreateDateTime,
            UpdateDateTime = oth.UpdateDateTime,
        };
    }
}