namespace InternetProvider.API.Mappers.Interfaces;

public interface IUserMapper<out T, in TRegisterRequestDto>
{
    public T ToEntity(TRegisterRequestDto regDto, string userId);
}