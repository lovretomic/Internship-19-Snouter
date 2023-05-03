using Microsoft.AspNetCore.Mvc;
using Snouter.Api.Mapping;
using Snouter.Application.Models.Item;
using Snouter.Application.Repositories;
using Snouter.Application.Services;
using Snouter.Contracts.Requests;

namespace Snouter.Api.Controllers;

public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpPost]
    [Route(ApiEndpoints.Item.Create)]
    public async Task<IActionResult> Create([FromBody] CreateItemRequest request, CancellationToken token = default)
    {
        var item = request.MapToItem();
        var isCreated = _itemService.CreateAsync(item, token).Result;
        if (!isCreated)
        {
            return BadRequest();
        }

        var response = item.MapToResponse();
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }
    
    [HttpGet]
    [Route(ApiEndpoints.Item.GetById)]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken token)
    {
        var item = await _itemService.GetByIdAsync(id, token);
        if (item is null)
        {
            return NotFound();
        }

        var response = item.MapToResponse();
        return Ok(response);
    }

    [HttpDelete]
    [Route(ApiEndpoints.Item.DeleteById)]
    public async Task<IActionResult> DeleteById([FromRoute] Guid id, CancellationToken token)
    {
        var isDeleted = await _itemService.DeleteByIdAsync(id, token);
        if (!isDeleted)
        {
            return BadRequest();
        }   
        return Ok(isDeleted);
    }

    [HttpPut]
    [Route(ApiEndpoints.Item.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateItemRequest request, CancellationToken token)
    {
        var task = request.MapToTask(id);
        var isUpdated = await _itemService.UpdateAsync(task, token);
        if (!isUpdated)
        {
            return NotFound();
        }

        var response = task.MapToResponse();
        return Ok(response);
    }
}