namespace InternetProvider.Infrastructure.Models;

public class InternetConnectionRequestStatus
{
    public int InternetConnectionRequestStatusId { get; set; }

    public string? InternetConnectionRequestStatusName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<InternetConnectionRequest> InternetConnectionRequests { get; set; } = new List<InternetConnectionRequest>();
}
