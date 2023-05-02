using Microsoft.AspNetCore.Mvc;
using Snouter.Api.Mapping;
using Snouter.Application.Models.Item;
using Snouter.Application.Repositories;
using Snouter.Application.Services;
using Snouter.Contracts.Requests;

namespace Snouter.Api.Controllers;

public class ItemsController : ControllerBase
{
    private readonly IItemRepository _itemRepository;
    private readonly IItemService _itemService;

    public ItemsController(IItemRepository itemRepository, IItemService itemService)
    {
        _itemRepository = itemRepository;
        _itemService = itemService;
    }

    [HttpPost]
    [Route(ApiEndpoints.Item.Create)]
    public async Task<IActionResult> Create([FromBody] CreateItemRequest request)
    {
        var item = request.MapToItem();
        var isCreated = _itemService.CreateAsync(item).Result;
        if (!isCreated)
        {
            return BadRequest();
        }

        var response = item.MapToResponse();
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }
    
    [HttpGet]
    [Route(ApiEndpoints.Item.GetById)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var item = await _itemService.GetByIdAsync(id);
        if (item is null)
        {
            return NotFound();
        }

        var response = item.MapToResponse();
        return Ok(response);
    }

    [HttpDelete]
    [Route(ApiEndpoints.Item.DeleteById)]
    public async Task<IActionResult> DeleteById([FromRoute] Guid id)
    {
        var isDeleted = await _itemService.DeleteByIdAsync(id);
        if (!isDeleted)
        {
            return BadRequest();
        }   
        return Ok(isDeleted);
    }

    [HttpPut]
    [Route(ApiEndpoints.Item.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateItemRequest request)
    {
        var task = request.MapToTask(id);
        var isUpdated = await _itemService.UpdateAsync(task);
        if (!isUpdated)
        {
            return NotFound();
        }

        var response = task.MapToResponse();
        return Ok(response);
    }
}