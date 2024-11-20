using InternetProvider.Application.DTOs.AuthDTOs;

namespace InternetProvider.Application.Interfaces.Services;

public interface IClientLoginService : IAppLoginService<LoginClientRequestDto, LoginClientResponseDto> { }