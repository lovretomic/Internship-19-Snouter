using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Snouter.Api.Mapping;
using Snouter.Application.Repositories;
using Snouter.Application.Services;
using Snouter.Contracts.Requests;

namespace Snouter.Api.Controllers;

[Authorize]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    
    [Authorize("Admin")]
    [HttpPost]
    [Route(ApiEndpoints.User.Create)]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken token)
    {
        var user = request.MapToUser();
        var isCreated = _userService.CreateAsync(user, token).Result;
        if (!isCreated)
        {
            return BadRequest();
        }

        var response = user.MapToResponse();
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpGet]
    [Route(ApiEndpoints.User.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var users = await _userService.GetAllAsync(token);
        return Ok(users);
    }
    
    [HttpGet]
    [Route(ApiEndpoints.User.GetById)]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken token)
    {
        var user = await _userService.GetByIdAsync(id, token);
        if (user is null)
        {
            return NotFound();
        }

        var response = user.MapToResponse();
        return Ok(response);
    }
    
    [Authorize("User")]
    [HttpPut]
    [Route(ApiEndpoints.User.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserRequest request, CancellationToken token)
    {
        var user = request.MapToUser(id);
        var isUpdated = await _userService.UpdateAsync(user, token);
        if (!isUpdated)
        {
            return NotFound();
        }

        var response = user.MapToResponse();
        return Ok(response);
    }

    [Authorize("Admin")]
    [HttpDelete]
    [Route(ApiEndpoints.User.DeleteById)]
    public async Task<IActionResult> DeleteById([FromRoute] Guid id, CancellationToken token)
    {
        var isDeleted = await _userService.DeleteByIdAsync(id, token);
        if (!isDeleted)
        {
            return BadRequest();
        }   
        return Ok(isDeleted);
    }
}