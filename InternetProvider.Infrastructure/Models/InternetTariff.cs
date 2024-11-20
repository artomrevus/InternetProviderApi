namespace InternetProvider.Infrastructure.Models;

public class InternetTariff
{
    public int InternetTariffId { get; set; }

    public int InternetTariffStatusId { get; set; }

    public int LocationTypeId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int InternetSpeedMbits { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<InternetConnectionRequest> InternetConnectionRequests { get; set; } = new List<InternetConnectionRequest>();

    public virtual InternetTariffStatus InternetTariffStatus { get; set; } = null!;

    public virtual LocationType LocationType { get; set; } = null!;
}
