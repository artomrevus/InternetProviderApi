using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;

namespace InternetProvider.Application.Interfaces.Services;

public interface ILocationService : IAppCrudService<LocationRequestDto, LocationResponseDto>, IGetService<LocationResponseDto> { }