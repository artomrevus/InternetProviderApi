using InternetProvider.Abstraction.Entities;

namespace InternetProvider.Infrastructure.Models;

public class City : ICity
{
    public int CityId { get; set; }

    public string? CityName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<Office> Offices { get; set; } = new List<Office>();

    public virtual ICollection<Street> Streets { get; set; } = new List<Street>();
    
    ICollection<IStreet> ICity.Streets
    {
        get => Streets.Cast<IStreet>().ToList();
        set => Streets = value.Cast<Street>().ToList();
    }
}
