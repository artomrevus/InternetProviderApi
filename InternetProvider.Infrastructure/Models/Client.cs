namespace InternetProvider.Infrastructure.Models;

public class Client
{
    public int ClientId { get; set; }

    public int ClientStatusId { get; set; }

    public int LocationId { get; set; }
    
    public string? UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly RegistrationDate { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ClientStatus ClientStatus { get; set; } = null!;

    public virtual ICollection<InternetConnectionRequest> InternetConnectionRequests { get; set; } = new List<InternetConnectionRequest>();

    public virtual Location Location { get; set; } = null!;
}
