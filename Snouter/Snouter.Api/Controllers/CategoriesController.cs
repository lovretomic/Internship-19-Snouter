using Microsoft.AspNetCore.Mvc;
using Snouter.Api.Mapping;
using Snouter.Application.Models;
using Snouter.Application.Repositories;
using Snouter.Contracts.Requests;

namespace Snouter.Api.Controllers;

public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    [Route(ApiEndpoints.Category.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var posts = await _categoryRepository.GetAllAsync();
        return Ok(posts);
    }

    [HttpPost]
    [Route(ApiEndpoints.Category.Create)]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
    {
        var category = request.MapToCategory();
        var isCreated = await _categoryRepository.CreateAsync(category);
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
        var isDeleted = await _categoryRepository.DeleteByNameAsync(name);
        if (!isDeleted)
        {
            return BadRequest();
        }   
        return Ok(isDeleted);
    }
}