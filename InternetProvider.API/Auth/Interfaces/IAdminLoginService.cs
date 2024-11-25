using InternetProvider.API.DTOs.AuthDTOs;

namespace InternetProvider.API.Auth.Interfaces;

public interface IAdminLoginService : IAppLoginService<LoginAdminRequestDto, LoginAdminResponseDto> { }