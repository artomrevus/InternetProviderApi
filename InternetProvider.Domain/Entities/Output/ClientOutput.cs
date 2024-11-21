namespace InternetProvider.Domain.Entities.Output;

public class ClientOutput
{
    public int Id { get; set; }
    
    public string? ClientStatusName { get; set; }
    public string? LocationTypeName { get; set; }
    public string? CityName { get; set; }
    public string? StreetName { get; set; }
    public string? HouseNumber { get; set; }
    public int? ApartmentNumber { get; set; }
    
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateOnly RegistrationDate { get; set; }
    
    public DateTime CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}