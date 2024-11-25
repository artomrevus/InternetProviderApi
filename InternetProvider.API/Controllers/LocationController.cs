using InternetProvider.Abstraction.Entities;
using InternetProvider.Abstraction.Exceptions;
using InternetProvider.Abstraction.Services;
using InternetProvider.Abstraction.Sort;
using InternetProvider.API.DTOs.RequestDTOs;
using InternetProvider.API.DTOs.ResponseDTOs;
using InternetProvider.API.Extensions;
using InternetProvider.API.Mappers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternetProvider.API.Controllers;

[Route("[controller]")]
[ApiController]
public class LocationController(ILocationService service, IMapper<ILocation, LocationRequestDto, LocationResponseDto> mapper) : ControllerBase
{
    [HttpGet("{id:int:min(1)}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            var responseObj = await service.GetByIdAsync(id);
            return Ok(mapper.ToResponseDto(responseObj));
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
    public async Task<IActionResult> Get(
        [FromQuery] string? filter = null,
        [FromQuery] string? sort = null,
        [FromQuery] int? pageNumber = null,
        [FromQuery] int? pageSize = null)
    {
        try
        {
            IEnumerable<ILocation> responseObj;
            if (filter is null && sort is null && pageNumber is null && pageSize is null)
            {
                responseObj = await service.GetAllAsync();
            }
            else
            {
                responseObj = await service.GetAsync(
                    filter.FromJsonToDictionary<string, object>(),
                    sort.FromJsonToDictionary<string, SortType>(),
                    pageNumber, 
                    pageSize);
            }
            
            return Ok(responseObj.Select(mapper.ToResponseDto));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet]
    [Route("Count")]
    public async Task<IActionResult> Count([FromQuery] string? filter = null)
    {
        try
        {
            var count = await service.CountAsync(filter.FromJsonToDictionary<string, object>());
            return Ok(count);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add([FromBody] LocationRequestDto dto)
    {
        try
        {
            await service.AddAsync(mapper.ToEntity(dto));
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
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] LocationRequestDto dto)
    {
        try
        {
            await service.UpdateAsync(id, mapper.ToEntity(dto));
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
            await service.DeleteAsync(id);
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