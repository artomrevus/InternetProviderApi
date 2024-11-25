using System.ComponentModel.DataAnnotations;

namespace InternetProvider.API.DTOs.RequestDTOs;

public class HouseRequestDto
{
    [Required]
    public int StreetId { get; set; }
    
    [Required]
    public string? HouseNumber { get; set; }
}