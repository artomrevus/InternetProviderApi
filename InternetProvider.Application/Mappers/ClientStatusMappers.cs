using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Domain.Entities;

namespace InternetProvider.Application.Mappers;

public static class ClientStatusMappers
{
    public static ClientStatusResponseDto ToClientStatusResponseDto(this ClientStatusOutput oth)
    {
        return new ClientStatusResponseDto()
        {
            Id = oth.Id,
            Name = oth.Name,
        };
    }
    
    public static ClientStatusInput ToDomainClientStatusInput(this ClientStatusRequestDto oth)
    {
        return new ClientStatusInput()
        {
            Name = oth.Name,
        };
    }
}