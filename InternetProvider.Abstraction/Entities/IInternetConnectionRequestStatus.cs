namespace InternetProvider.Abstraction.Entities;

public interface IInternetConnectionRequestStatus
{
    public int InternetConnectionRequestStatusId { get; set; }

    public string? InternetConnectionRequestStatusName { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public ICollection<IInternetConnectionRequest> InternetConnectionRequests { get; set; }
}