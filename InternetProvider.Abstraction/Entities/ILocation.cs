namespace InternetProvider.Abstraction.Entities;

public interface ILocation
{
    public int LocationId { get; set; }

    public int LocationTypeId { get; set; }

    public int HouseId { get; set; }

    public int? ApartmentNumber { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<IClient> Clients { get; set; }

    public IHouse House { get; set; }

    public ILocationType LocationType { get; set; }
}