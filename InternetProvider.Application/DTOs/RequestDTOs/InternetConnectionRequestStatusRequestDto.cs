using System.ComponentModel.DataAnnotations;

namespace InternetProvider.Application.DTOs.RequestDTOs;

public class InternetConnectionRequestStatusRequestDto
{
    [Required]
    public string? Name { get; set; }
}