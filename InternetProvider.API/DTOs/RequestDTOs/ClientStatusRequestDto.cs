using System.ComponentModel.DataAnnotations;

namespace InternetProvider.API.DTOs.RequestDTOs;

public class ClientStatusRequestDto
{
    [Required]
    public string? Name { get; set; }
}