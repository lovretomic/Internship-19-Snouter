using Microsoft.AspNetCore.Mvc;
using Snouter.Application.Repositories;

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
}