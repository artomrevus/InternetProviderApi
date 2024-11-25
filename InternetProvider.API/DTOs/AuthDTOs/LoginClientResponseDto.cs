namespace InternetProvider.API.DTOs.AuthDTOs;

public class LoginClientResponseDto
{
    public string UserName { get; set; } = default!;
    public string Token { get; set; } = default!;
    public string Role { get; set; } = default!;
    public int ClientId { get; set; }
}