using InternetProvider.Application.DTOs.AuthDTOs;

namespace InternetProvider.Application.Interfaces.Services;

public interface IAdminLoginService : IAppLoginService<LoginAdminRequestDto, LoginAdminResponseDto> { }