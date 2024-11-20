using InternetProvider.Application.DTOs.AuthDTOs;

namespace InternetProvider.Application.Interfaces.Services;

public interface IClientRegisterService : IAppRegisterService<RegisterClientRequestDto, RegisterClientResponseDto> { }