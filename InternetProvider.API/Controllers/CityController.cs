using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.Interfaces.Services;
using InternetProvider.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternetProvider.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CityController(ICityService appService) : ControllerBase
{
    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            var responseObj = await appService.GetByIdAsync(id);
            return Ok(responseObj);
        }
        catch (RepositoryException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var responseObj = await appService.GetAllAsync();
            return Ok(responseObj);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add([FromBody] CityRequestDto dto)
    {
        try
        {
            await appService.AddAsync(dto);
            return Created();
        }
        catch (RepositoryException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    
    [HttpPut]
    [Route("{id:int:min(1)}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CityRequestDto dto)
    {
        try
        {
            await appService.UpdateAsync(id, dto);
            return NoContent();
        }
        catch (RepositoryException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    
    [HttpDelete("{id:int:min(1)}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await appService.DeleteAsync(id);
            return NoContent();
        }
        catch (RepositoryException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}