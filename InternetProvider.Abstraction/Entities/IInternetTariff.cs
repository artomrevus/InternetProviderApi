namespace InternetProvider.Abstraction.Entities;

public interface IInternetTariff
{
    public int InternetTariffId { get; set; }

    public int InternetTariffStatusId { get; set; }

    public int LocationTypeId { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int InternetSpeedMbits { get; set; }

    public string Description { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<IInternetConnectionRequest> InternetConnectionRequests { get; set; }

    public IInternetTariffStatus InternetTariffStatus { get; set; }

    public ILocationType LocationType { get; set; } 
}