using InternetProvider.Abstraction.Entities;

namespace InternetProvider.Infrastructure.Models;

public class InternetTariffStatus : IInternetTariffStatus
{
    public int InternetTariffStatusId { get; set; }

    public string? InternetTariffStatusName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<InternetTariff> InternetTariffs { get; set; } = new List<InternetTariff>();
    
    ICollection<IInternetTariff> IInternetTariffStatus.InternetTariffs
    {
        get => InternetTariffs.Cast<IInternetTariff>().ToList();
        set => InternetTariffs = value.Cast<InternetTariff>().ToList();
    }
}
