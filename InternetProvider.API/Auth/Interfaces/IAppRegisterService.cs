namespace InternetProvider.API.Auth.Interfaces;

public interface IAppRegisterService<TRegisterRequestDto, TRegisterResponseDto>
    where TRegisterRequestDto : class
    where TRegisterResponseDto : class
{
    Task<TRegisterResponseDto> RegisterAsync(TRegisterRequestDto entity);
}