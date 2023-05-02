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
    public async Task<IActionResult> GetAll()
    {
        var categories = await _categoryService.GetAllAsync();
        return Ok(categories);
    }

    [HttpPost]
    [Route(ApiEndpoints.Category.Create)]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
    {
        var category = request.MapToCategory();
        var isCreated = await _categoryService.CreateAsync(category);
        if (!isCreated)
        {
            return BadRequest();
        }

        return Ok(isCreated);
    }

    [HttpDelete]
    [Route(ApiEndpoints.Category.DeleteByName)]
    public async Task<IActionResult> Delete([FromRoute] string name)
    {
        var isDeleted = await _categoryService.DeleteByNameAsync(name);
        if (!isDeleted)
        {
            return BadRequest();
        }   
        return Ok(isDeleted);
    }
}