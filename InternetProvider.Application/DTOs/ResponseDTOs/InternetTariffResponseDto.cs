namespace InternetProvider.Application.DTOs.ResponseDTOs;

public class InternetTariffResponseDto
{
    public int Id { get; set; }
    public string? InternetTariffStatusName { get; set; }
    public string? LocationTypeName { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int InternetSpeedMbits { get; set; }
    public string Description { get; set; } = null!;
}