using InternetProvider.Abstraction.Entities;
using InternetProvider.API.DTOs.RequestDTOs;
using InternetProvider.API.DTOs.ResponseDTOs;
using InternetProvider.API.Mappers.Interfaces;

namespace InternetProvider.API.Mappers.Mappers;

public class InternetConnectionRequestStatusMapper(IInternetConnectionRequestStatus internetConnectionRequestStatus) : IMapper<IInternetConnectionRequestStatus, InternetConnectionRequestStatusRequestDto, InternetConnectionRequestStatusResponseDto>
{
    public InternetConnectionRequestStatusResponseDto ToResponseDto(IInternetConnectionRequestStatus oth)
    {
        return new InternetConnectionRequestStatusResponseDto()
        {
            Id = oth.InternetConnectionRequestStatusId,
            Name = oth.InternetConnectionRequestStatusName
        };
    }

    public IInternetConnectionRequestStatus ToEntity(InternetConnectionRequestStatusRequestDto oth)
    {
        internetConnectionRequestStatus.InternetConnectionRequestStatusName = oth.Name;
        
        return internetConnectionRequestStatus;
    }
}