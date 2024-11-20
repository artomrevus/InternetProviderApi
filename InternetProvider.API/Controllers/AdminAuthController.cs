using InternetProvider.Application.DTOs.AuthDTOs;
using InternetProvider.Application.Exception;
using InternetProvider.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternetProvider.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminAuthController(IAdminLoginService loginService) : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginAdminRequestDto requestDto)
    {
        try
        {
            var responseObj = await loginService.LoginAsync(requestDto);
            return Ok(responseObj);
        }
        catch (AccessException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}