using InternetProvider.Abstraction.Entities;

namespace InternetProvider.Infrastructure.Models;

public class Street : IStreet
{
    public int StreetId { get; set; }

    public int CityId { get; set; }

    public string? StreetName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<House> Houses { get; set; } = new List<House>();
    
    
    ICity IStreet.City
    {
        get => City;
        set => City = (City)value;
    }

    ICollection<IHouse> IStreet.Houses
    {
        get => Houses.Cast<IHouse>().ToList();
        set => Houses = value.Cast<House>().ToList();
    }
}
