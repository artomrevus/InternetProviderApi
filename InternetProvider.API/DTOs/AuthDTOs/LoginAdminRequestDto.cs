namespace InternetProvider.API.DTOs.AuthDTOs;

public class LoginAdminRequestDto
{ 
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
}