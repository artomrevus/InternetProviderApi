using System.ComponentModel.DataAnnotations;

namespace InternetProvider.Application.DTOs.RequestDTOs;

public class InternetTariffStatusRequestDto
{
    [Required]
    public string? Name { get; set; }
}