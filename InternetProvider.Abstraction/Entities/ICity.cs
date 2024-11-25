namespace InternetProvider.Abstraction.Entities;

public interface ICity
{
    public int CityId { get; set; }

    public string? CityName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<IStreet> Streets { get; set; }
}