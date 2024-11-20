using System.ComponentModel.DataAnnotations;

namespace InternetProvider.Application.DTOs.RequestDTOs;

public class CityRequestDto
{
    [Required]
    public string? Name { get; set; }
}