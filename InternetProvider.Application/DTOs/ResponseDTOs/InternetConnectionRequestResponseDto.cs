namespace InternetProvider.Application.DTOs.ResponseDTOs;

public class InternetConnectionRequestResponseDto
{
    public int Id { get; set; }
    public string ClientPhoneNumber { get; set; } = null!;
    public string ClientEmail { get; set; } = null!;
    public string InternetTariffName { get; set; } = null!;
    public decimal InternetTariffPrice { get; set; }
    public int InternetTariffSpeedMbits { get; set; }
    public string? InternetConnectionRequestStatusName { get; set; }
    public string Number { get; set; } = null!;
    public DateOnly RequestDate { get; set; }
}