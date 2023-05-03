﻿using Microsoft.AspNetCore.Mvc;
using Snouter.Api.Mapping;
using Snouter.Application.Models;
using Snouter.Application.Repositories;
using Snouter.Application.Services;
using Snouter.Contracts.Requests;

namespace Snouter.Api.Controllers;

public class SubcategoriesController : ControllerBase
{
    private readonly ISubcategoryRepository _subcategoryRepository;
    private readonly ISubcategoryService _subcategoryService;

    public SubcategoriesController(ISubcategoryRepository subcategoryRepository, ISubcategoryService subcategoryService)
    {
        _subcategoryRepository = subcategoryRepository;
        _subcategoryService = subcategoryService;
    }

    [HttpGet]
    [Route(ApiEndpoints.Subcategory.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var subcategories = await _subcategoryService.GetAllAsync(token);
        return Ok(subcategories);
    }

    [HttpPost]
    [Route(ApiEndpoints.Subcategory.Create)]
    public async Task<IActionResult> Create([FromBody] CreateSubcategoryRequest request,  [FromRoute] string categoryName, CancellationToken token)
    {
        var subcategory = request.MapToSubcategory(categoryName);
        var isCreated = await _subcategoryService.CreateAsync(subcategory, categoryName, token);
        if (!isCreated)
        {
            return BadRequest();
        }

        return Ok(isCreated);
    }

    [HttpDelete]
    [Route(ApiEndpoints.Subcategory.DeleteByName)]
    public async Task<IActionResult> DeleteByName([FromRoute] string name, CancellationToken token = default)
    {
        var isDeleted = await _subcategoryService.DeleteByNameAsync(name, token);
        if (!isDeleted)
        {
            return BadRequest();
        }   
        return Ok(isDeleted);
    }
}