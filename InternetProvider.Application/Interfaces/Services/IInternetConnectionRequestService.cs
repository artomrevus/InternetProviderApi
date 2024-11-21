using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;

namespace InternetProvider.Application.Interfaces.Services;

public interface IInternetConnectionRequestService : IAppCrudService<InternetConnectionRequestRequestDto, InternetConnectionRequestResponseDto>, IGetService<InternetConnectionRequestResponseDto> { }