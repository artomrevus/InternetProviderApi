using InternetProvider.API.DTOs.AuthDTOs;

namespace InternetProvider.API.Auth.Interfaces;

public interface IClientLoginService : IAppLoginService<LoginClientRequestDto, LoginClientResponseDto> { }