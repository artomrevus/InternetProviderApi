using System.ComponentModel.DataAnnotations;

namespace InternetProvider.Application.DTOs.RequestDTOs;

public class ClientStatusRequestDto
{
    [Required]
    public string? Name { get; set; }
}