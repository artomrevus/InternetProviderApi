using System.ComponentModel.DataAnnotations;

namespace InternetProvider.Application.DTOs.RequestDTOs;

public class HouseRequestDto
{
    [Required]
    public int StreetId { get; set; }
    
    [Required]
    public string? HouseNumber { get; set; }
}