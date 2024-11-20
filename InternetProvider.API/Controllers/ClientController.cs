using InternetProvider.API.Extensions;
using InternetProvider.Application.DTOs.RequestDTOs;
using InternetProvider.Application.DTOs.ResponseDTOs;
using InternetProvider.Application.Interfaces.Services;
using InternetProvider.GeneralTypes.Sort;
using InternetProvider.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternetProvider.API.Controllers;

[Route("[controller]")]
[ApiController]
public class ClientController(IClientService appService) : ControllerBase
{
    [HttpGet("{id:int:min(1)}")]
    [Authorize(Roles = "Admin, Client")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            var userId = User.FindFirst("id")?.Value;
            if (userId is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "User id not found.");
            }
            
            var hasUserAccess = await appService.HasUserAccess(id, userId);
            if (!hasUserAccess)
            {
                return Forbid();
            }
            
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
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Get(
        [FromQuery] string? filter = null,
        [FromQuery] string? sort = null,
        [FromQuery] int? pageNumber = null,
        [FromQuery] int? pageSize = null)
    {
        try
        {
            IEnumerable<ClientResponseDto> responseObj;
            if (filter is null && sort is null && pageNumber is null && pageSize is null)
            {
                responseObj = await appService.GetAllAsync();
            }
            else
            {
                responseObj = await appService.GetAsync(
                    filter.FromJsonToDictionary<string, object>(),
                    sort.FromJsonToDictionary<string, SortType>(),
                    pageNumber,
                    pageSize);
            }
            
            return Ok(responseObj);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    
    [HttpGet]
    [Route("Count")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Count([FromQuery] string? filter = null)
    {
        try
        {
            var count = await appService.CountAsync(filter.FromJsonToDictionary<string, object>());
            return Ok(count);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add([FromBody] ClientRequestDto dto)
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
    [Authorize(Roles = "Admin, Client")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ClientRequestDto dto)
    {
        try
        {
            var userId = User.FindFirst("id")?.Value;
            if (userId is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "User id not found.");
            }
            
            var hasUserAccess = await appService.HasUserAccess(accessedId: id, userId);
            if (!hasUserAccess)
            {
                return Forbid();
            }
            
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