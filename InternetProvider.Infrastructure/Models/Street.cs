namespace InternetProvider.Infrastructure.Models;

public class Street
{
    public int StreetId { get; set; }

    public int CityId { get; set; }

    public string? StreetName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<House> Houses { get; set; } = new List<House>();
}
