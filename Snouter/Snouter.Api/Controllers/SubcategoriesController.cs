using Microsoft.AspNetCore.Mvc;
using Snouter.Api.Mapping;
using Snouter.Application.Models;
using Snouter.Application.Repositories;
using Snouter.Contracts.Requests;

namespace Snouter.Api.Controllers;

public class SubcategoriesController : ControllerBase
{
    private readonly ISubcategoryRepository _subcategoryRepository;

    public SubcategoriesController(ISubcategoryRepository subcategoryRepository)
    {
        _subcategoryRepository = subcategoryRepository;
    }

    [HttpGet]
    [Route(ApiEndpoints.Subcategory.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var subcategories = await _subcategoryRepository.GetAllAsync();
        return Ok(subcategories);
    }

    [HttpPost]
    [Route(ApiEndpoints.Subcategory.Create)]
    public async Task<IActionResult> Create([FromBody] CreateSubcategoryRequest request,  [FromRoute] string categoryName)
    {
        var subcategory = request.MapToSubcategory(categoryName);
        var isCreated = await _subcategoryRepository.CreateAsync(subcategory);
        if (!isCreated)
        {
            return BadRequest();
        }

        return Ok(isCreated);
    }

    [HttpDelete]
    [Route(ApiEndpoints.Subcategory.DeleteByName)]
    public async Task<IActionResult> DeleteByName([FromRoute] string name)
    {
        var isDeleted = await _subcategoryRepository.DeleteByNameAsync(name);
        if (!isDeleted)
        {
            return BadRequest();
        }   
        return Ok(isDeleted);
    }
}