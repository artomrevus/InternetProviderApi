using System.ComponentModel.DataAnnotations;

namespace InternetProvider.API.DTOs.RequestDTOs;

public class InternetTariffStatusRequestDto
{
    [Required]
    public string? Name { get; set; }
}