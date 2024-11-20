namespace InternetProvider.Domain.Entities;

public class StreetOutput
{
    public int Id { get; set; }

    public string? CityName { get; set; }

    public string? StreetName { get; set; }

    public DateTime CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}