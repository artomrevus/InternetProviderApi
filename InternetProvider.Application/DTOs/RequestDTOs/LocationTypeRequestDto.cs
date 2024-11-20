using System.ComponentModel.DataAnnotations;

namespace InternetProvider.Application.DTOs.RequestDTOs;

public class LocationTypeRequestDto
{
    [Required]
    public string? Name { get; set; }
}