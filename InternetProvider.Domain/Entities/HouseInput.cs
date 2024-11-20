namespace InternetProvider.Domain.Entities;

public class HouseInput
{
    public int StreetId { get; set; }

    public string? HouseNumber { get; set; }

    public DateTime CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}