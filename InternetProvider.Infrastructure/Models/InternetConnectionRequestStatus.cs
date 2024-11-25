using InternetProvider.Abstraction.Entities;

namespace InternetProvider.Infrastructure.Models;

public class InternetConnectionRequestStatus : IInternetConnectionRequestStatus
{
    public int InternetConnectionRequestStatusId { get; set; }

    public string? InternetConnectionRequestStatusName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<InternetConnectionRequest> InternetConnectionRequests { get; set; } = new List<InternetConnectionRequest>();
    
    ICollection<IInternetConnectionRequest> IInternetConnectionRequestStatus.InternetConnectionRequests
    {
        get => InternetConnectionRequests.Cast<IInternetConnectionRequest>().ToList();
        set => InternetConnectionRequests = value.Cast<InternetConnectionRequest>().ToList();
    }
}
