using Microsoft.AspNetCore.Mvc;
using Snouter.Api.Mapping;
using Snouter.Application.Repositories;
using Snouter.Contracts.Requests;

namespace Snouter.Api.Controllers;

[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    [Route(ApiEndpoints.User.Create)]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
    {
        var user = request.MapToUser();
        var isCreated = _userRepository.CreateAsync(user).Result;
        if (!isCreated)
        {
            return BadRequest();
        }

        var response = user.MapToResponse();
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpGet]
    [Route(ApiEndpoints.User.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userRepository.GetAllAsync();
        return Ok(users);
    }
    
    [HttpGet]
    [Route(ApiEndpoints.User.GetById)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user is null)
        {
            return NotFound();
        }

        var response = user.MapToResponse();
        return Ok(response);
    }

    [HttpPut]
    [Route(ApiEndpoints.User.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserRequest request)
    {
        var user = request.MapToUser(id);
        var isUpdated = await _userRepository.UpdateAsync(user);
        if (!isUpdated)
        {
            return NotFound();
        }

        var response = user.MapToResponse();
        return Ok(response);
    }

    [HttpDelete]
    [Route(ApiEndpoints.User.DeleteById)]
    public async Task<IActionResult> DeleteById([FromRoute] Guid id)
    {
        var isDeleted = await _userRepository.DeleteByIdAsync(id);
        if (!isDeleted)
        {
            return BadRequest();
        }   
        return Ok(isDeleted);
    }
}