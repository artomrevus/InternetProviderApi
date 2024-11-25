using System.ComponentModel.DataAnnotations;

namespace InternetProvider.API.DTOs.AuthDTOs;

public class RegisterClientRequestDto
{
    [Required]
    public string UserName { get; set; } = default!;
    [Required]
    public string Password { get; set; } = default!;
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