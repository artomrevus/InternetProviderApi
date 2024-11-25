using InternetProvider.Abstraction.Exceptions;
using InternetProvider.API.Auth.Interfaces;
using InternetProvider.API.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Mvc;

namespace InternetProvider.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientAuthController(IClientRegisterService registerService, IClientLoginService loginService) : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterClientRequestDto requestDto)
    {
        try
        {
            var responseObj = await registerService.RegisterAsync(requestDto);
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
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginClientRequestDto requestDto)
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