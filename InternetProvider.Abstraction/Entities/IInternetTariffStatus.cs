namespace InternetProvider.Abstraction.Entities;

public interface IInternetTariffStatus
{
    public int InternetTariffStatusId { get; set; }

    public string? InternetTariffStatusName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<IInternetTariff> InternetTariffs { get; set; }
}