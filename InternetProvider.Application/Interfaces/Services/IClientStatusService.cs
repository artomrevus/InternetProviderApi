using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;

namespace InternetProvider.Application.Interfaces.Services;

public interface IClientStatusService : IAppCrudService<ClientStatusRequestDto, ClientStatusResponseDto> { }