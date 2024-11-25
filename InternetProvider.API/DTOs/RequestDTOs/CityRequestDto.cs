using System.ComponentModel.DataAnnotations;

namespace InternetProvider.API.DTOs.RequestDTOs;

public class CityRequestDto
{
    [Required]
    public string? Name { get; set; }
}