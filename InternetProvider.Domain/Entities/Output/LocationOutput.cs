namespace InternetProvider.Domain.Entities.Output;

public class LocationOutput
{
    public int Id { get; set; }

    public string? LocationTypeName { get; set; }
    public string? CityName { get; set; }
    public string? StreetName { get; set; }
    public string? HouseNumber { get; set; }

    public int? ApartmentNumber { get; set; }

    public DateTime CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}