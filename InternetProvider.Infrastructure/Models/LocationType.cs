using InternetProvider.Abstraction.Entities;

namespace InternetProvider.Infrastructure.Models;

public class LocationType : ILocationType
{
    public int LocationTypeId { get; set; }

    public string? LocationTypeName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<InternetTariff> InternetTariffs { get; set; } = new List<InternetTariff>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
    
    ICollection<IInternetTariff> ILocationType.InternetTariffs
    {
        get => InternetTariffs.Cast<IInternetTariff>().ToList();
        set => InternetTariffs = value.Cast<InternetTariff>().ToList();
    }
    
    ICollection<ILocation> ILocationType.Locations
    {
        get => Locations.Cast<ILocation>().ToList();
        set => Locations = value.Cast<Location>().ToList();
    }
}
