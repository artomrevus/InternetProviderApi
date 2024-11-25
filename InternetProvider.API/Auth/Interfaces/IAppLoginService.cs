namespace InternetProvider.API.Auth.Interfaces;

public interface IAppLoginService<TLoginRequestDto, TLoginResponseDto>
    where TLoginRequestDto : class
    where TLoginResponseDto : class
{
    Task<TLoginResponseDto> LoginAsync(TLoginRequestDto entity);
}