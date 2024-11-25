using System.ComponentModel.DataAnnotations;

namespace InternetProvider.API.DTOs.RequestDTOs;

public class LocationTypeRequestDto
{
    [Required]
    public string? Name { get; set; }
}