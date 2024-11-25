using InternetProvider.Abstraction.Entities;

namespace InternetProvider.Infrastructure.Models;

public class House : IHouse
{
    public int HouseId { get; set; }

    public int StreetId { get; set; }

    public string? HouseNumber { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual Street Street { get; set; } = null!;
    
    
    ICollection<ILocation> IHouse.Locations
    {
        get => Locations.Cast<ILocation>().ToList();
        set => Locations = value.Cast<Location>().ToList();
    }

    IStreet IHouse.Street
    {
        get => Street;
        set => Street = (Street)value;
    }
}
