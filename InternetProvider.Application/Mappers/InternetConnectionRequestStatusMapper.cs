using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Domain.Entities.Input;
using InternetProvider.Domain.Entities.Output;

namespace InternetProvider.Application.Mappers;

public static class InternetConnectionRequestStatusMapper
{
    public static InternetConnectionRequestStatusResponseDto ToInternetConnectionRequestStatusResponseDto(this InternetConnectionRequestStatusOutput oth)
    {
        return new InternetConnectionRequestStatusResponseDto()
        {
            Id = oth.Id,
            Name = oth.Name,
        };
    }
    
    public static InternetConnectionRequestStatusInput ToDomainInternetConnectionRequestStatusInput(this InternetConnectionRequestStatusRequestDto oth)
    {
        return new InternetConnectionRequestStatusInput()
        {
            Name = oth.Name,
        };
    }
}