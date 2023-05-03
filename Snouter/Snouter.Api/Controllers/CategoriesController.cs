using Microsoft.AspNetCore.Mvc;
using Snouter.Api.Mapping;
using Snouter.Application.Models;
using Snouter.Application.Repositories;
using Snouter.Application.Services;
using Snouter.Contracts.Requests;

namespace Snouter.Api.Controllers;

public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryRepository categoryRepository, ICategoryService categoryService)
    {
        _categoryRepository = categoryRepository;
        _categoryService = categoryService;
    }

    [HttpGet]
    [Route(ApiEndpoints.Category.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var categories = await _categoryService.GetAllAsync(token);
        return Ok(categories);
    }

    [HttpPost]
    [Route(ApiEndpoints.Category.Create)]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request, CancellationToken token)
    {
        var category = request.MapToCategory();
        var isCreated = await _categoryService.CreateAsync(category, token);
        if (!isCreated)
        {
            return BadRequest();
        }

        return Ok(isCreated);
    }

    [HttpDelete]
    [Route(ApiEndpoints.Category.DeleteByName)]
    public async Task<IActionResult> Delete([FromRoute] string name, CancellationToken token)
    {
        var isDeleted = await _categoryService.DeleteByNameAsync(name, token);
        if (!isDeleted)
        {
            return BadRequest();
        }   
        return Ok(isDeleted);
    }
}