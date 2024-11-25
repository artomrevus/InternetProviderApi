using InternetProvider.Abstraction.Entities;

namespace InternetProvider.Infrastructure.Models;

public class InternetConnectionRequest : IInternetConnectionRequest
{
    public int InternetConnectionRequestId { get; set; }

    public int ClientId { get; set; }

    public int InternetTariffId { get; set; }

    public int InternetConnectionRequestStatusId { get; set; }

    public string Number { get; set; } = null!;

    public DateOnly RequestDate { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Connection? Connection { get; set; }

    public virtual InternetConnectionRequestStatus InternetConnectionRequestStatus { get; set; } = null!;

    public virtual InternetTariff InternetTariff { get; set; } = null!;
    
    
    IClient IInternetConnectionRequest.Client
    {
        get => Client;
        set => Client = (Client)value;
    }
    
    IInternetConnectionRequestStatus IInternetConnectionRequest.InternetConnectionRequestStatus
    {
        get => InternetConnectionRequestStatus;
        set => InternetConnectionRequestStatus = (InternetConnectionRequestStatus)value;
    }

    IInternetTariff IInternetConnectionRequest.InternetTariff
    {
        get => InternetTariff;
        set => InternetTariff = (InternetTariff)value;
    }
}
