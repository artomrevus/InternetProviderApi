namespace InternetProvider.Abstraction.Entities;

public interface ILocationType
{
    public int LocationTypeId { get; set; }

    public string? LocationTypeName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<IInternetTariff> InternetTariffs { get; set; }

    public ICollection<ILocation> Locations { get; set; }
}