namespace InternetProvider.Abstraction.Entities;

public interface IHouse
{
    public int HouseId { get; set; }

    public int StreetId { get; set; }

    public string? HouseNumber { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<ILocation> Locations { get; set; }

    public IStreet Street { get; set; }
}