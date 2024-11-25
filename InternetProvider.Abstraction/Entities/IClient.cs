namespace InternetProvider.Abstraction.Entities;

public interface IClient
{
    public int ClientId { get; set; }

    public int ClientStatusId { get; set; }

    public int LocationId { get; set; }
    
    public string? UserId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public DateOnly RegistrationDate { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public IClientStatus ClientStatus { get; set; }

    public ICollection<IInternetConnectionRequest> InternetConnectionRequests { get; set; }

    public ILocation Location { get; set; }
}