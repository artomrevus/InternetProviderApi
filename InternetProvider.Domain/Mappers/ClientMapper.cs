using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;
using InternetProvider.Infrastructure.Models;

namespace InternetProvider.Domain.Mappers;

public static class ClientMapper
{
    public static ClientOutput ToDomainClientOutput(this Client oth)
    {
        return new ClientOutput()
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