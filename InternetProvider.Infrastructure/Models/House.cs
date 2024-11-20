namespace InternetProvider.Infrastructure.Models;

public class House
{
    public int HouseId { get; set; }

    public int StreetId { get; set; }

    public string? HouseNumber { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual Street Street { get; set; } = null!;
}
