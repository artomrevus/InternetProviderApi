namespace InternetProvider.API.DTOs.AuthDTOs;

public class RegisterClientResponseDto
{
    public string UserName { get; set; } = default!;
    public string Role { get; set; } = default!;
    public int ClientId { get; set; }
}