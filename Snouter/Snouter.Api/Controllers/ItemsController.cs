using Microsoft.AspNetCore.Mvc;
using Snouter.Api.Mapping;
using Snouter.Application.Repositories;

namespace Snouter.Api.Controllers;

public class ItemsController : ControllerBase
{
    private readonly IItemRepository _itemRepository;

    public ItemsController(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    [HttpGet]
    [Route(ApiEndpoints.Item.GetById)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var item = await _itemRepository.GetByIdAsync(id);
        if (item is null)
        {
            return NotFound();
        }

        var response = item.MapToResponse();
        return Ok(response);
    }
}