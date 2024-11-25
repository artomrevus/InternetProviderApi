namespace InternetProvider.Abstraction.Entities;

public interface IInternetConnectionRequest
{
    public int InternetConnectionRequestId { get; set; }

    public int ClientId { get; set; }

    public int InternetTariffId { get; set; }

    public int InternetConnectionRequestStatusId { get; set; }

    public string Number { get; set; }

    public DateOnly RequestDate { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public IClient Client { get; set; }

    public IInternetConnectionRequestStatus InternetConnectionRequestStatus { get; set; }

    public IInternetTariff InternetTariff { get; set; }
}