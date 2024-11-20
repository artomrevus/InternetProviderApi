namespace InternetProvider.Application.Interfaces.Services;

public interface IAppLoginService<TLoginRequestDto, TLoginResponseDto>
    where TLoginRequestDto : class
    where TLoginResponseDto : class
{
    Task<TLoginResponseDto> LoginAsync(TLoginRequestDto entity);
}