namespace InternetProvider.API.Mappers.Interfaces;

public interface IMapper<T, in TRequestDto, out TResponseDto>
{
    public TResponseDto ToResponseDto(T oth);
    public T ToEntity(TRequestDto oth);
}