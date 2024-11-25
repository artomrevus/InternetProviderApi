using System.ComponentModel.DataAnnotations;

namespace InternetProvider.API.DTOs.RequestDTOs;

public class InternetConnectionRequestStatusRequestDto
{
    [Required]
    public string? Name { get; set; }
}