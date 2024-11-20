using System.ComponentModel.DataAnnotations;

namespace InternetProvider.Application.DTOs.RequestDTOs;

public class StreetRequestDto
{
    [Required]
    public int CityId { get; set; }
    [Required]
    public string? Name { get; set; }
}