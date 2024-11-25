using System.ComponentModel.DataAnnotations;

namespace InternetProvider.API.DTOs.RequestDTOs;

public class LocationRequestDto
{
    [Required]
    public int LocationTypeId { get; set; }
    [Required]
    public int HouseId { get; set; }
    [Range(1, int.MaxValue)]
    public int? ApartmentNumber { get; set; }
}