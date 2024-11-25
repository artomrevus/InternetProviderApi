namespace InternetProvider.Abstraction.Entities;

public interface IStreet
{
    public int StreetId { get; set; }

    public int CityId { get; set; }

    public string? StreetName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICity City { get; set; }

    public ICollection<IHouse> Houses { get; set; }
}