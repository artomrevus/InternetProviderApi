namespace InternetProvider.Infrastructure.Models;

public class InternetTariffStatus
{
    public int InternetTariffStatusId { get; set; }

    public string? InternetTariffStatusName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<InternetTariff> InternetTariffs { get; set; } = new List<InternetTariff>();
}
