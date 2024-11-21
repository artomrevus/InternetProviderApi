namespace InternetProvider.Domain.Entities.Input;

public class HouseInput
{
    public int StreetId { get; set; }

    public string? HouseNumber { get; set; }

    public DateTime CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}