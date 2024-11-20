using System.ComponentModel.DataAnnotations;

namespace InternetProvider.Application.DTOs.RequestDTOs;

public class ClientRequestDto
{
    [Required]
    public int ClientStatusId { get; set; }
    [Required]
    public int LocationId { get; set; }
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
}