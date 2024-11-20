namespace InternetProvider.Application.DTOs.ResponseDTOs;

public class LocationResponseDto
{
    public int Id { get; set; }
    public string? LocationTypeName { get; set; }
    public string? CityName { get; set; }
    public string? StreetName { get; set; }
    public string? HouseNumber { get; set; }
    public int? ApartmentNumber { get; set; }
}