using System.ComponentModel.DataAnnotations;

namespace InternetProvider.API.DTOs.RequestDTOs;

public class InternetTariffRequestDto
{
    [Required]
    public int InternetTariffStatusId { get; set; }
    [Required]
    public int LocationTypeId { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int InternetSpeedMbits { get; set; }
    [Required]
    public string Description { get; set; } = null!;
}