namespace InternetProvider.Domain.Entities.Input;

public class ClientInput
{
    public int ClientStatusId { get; set; }
    public int LocationId { get; set; }
    public string UserId { get; set; } = null!;
    
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateOnly RegistrationDate { get; set; }
    
    public DateTime CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}