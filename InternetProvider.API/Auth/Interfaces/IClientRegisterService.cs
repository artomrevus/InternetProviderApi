using InternetProvider.API.DTOs.AuthDTOs;

namespace InternetProvider.API.Auth.Interfaces;

public interface IClientRegisterService : IAppRegisterService<RegisterClientRequestDto, RegisterClientResponseDto> { }