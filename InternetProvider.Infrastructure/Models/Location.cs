namespace InternetProvider.Infrastructure.Models;

public class Location
{
    public int LocationId { get; set; }

    public int LocationTypeId { get; set; }

    public int HouseId { get; set; }

    public int? ApartmentNumber { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual House House { get; set; } = null!;

    public virtual LocationType LocationType { get; set; } = null!;
}
