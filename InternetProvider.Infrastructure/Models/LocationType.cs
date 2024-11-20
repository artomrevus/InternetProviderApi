namespace InternetProvider.Infrastructure.Models;

public class LocationType
{
    public int LocationTypeId { get; set; }

    public string? LocationTypeName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<InternetTariff> InternetTariffs { get; set; } = new List<InternetTariff>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
