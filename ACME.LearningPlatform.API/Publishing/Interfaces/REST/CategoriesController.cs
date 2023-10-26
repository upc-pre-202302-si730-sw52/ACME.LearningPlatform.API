using ACME.LearningPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningPlatform.API.Publishing.Domain.Services;
using ACME.LearningPlatform.API.Publishing.Interfaces.REST.Resources;
using ACME.LearningPlatform.API.Publishing.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ACME.LearningPlatform.API.Publishing.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class CategoriesController: ControllerBase
{
    private readonly ICategoryCommandService _categoryCommandService;
    private readonly ICategoryQueryService _categoryQueryService;

    public CategoriesController(ICategoryCommandService categoryCommandService, ICategoryQueryService categoryQueryService)
    {
        _categoryCommandService = categoryCommandService;
        _categoryQueryService = categoryQueryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryResource createCategoryResource)
    {
        var createCategoryCommand = CreateCategoryCommandFromResourceAssembler.ToCommandFromResource(createCategoryResource);
        var category = await _categoryCommandService.Handle(createCategoryCommand);
        var resource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return CreatedAtAction(nameof(GetCategoryById), new { id = resource.Id }, resource);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var getCategoryByIdQuery = new GetCategoryByIdQuery(id);
        var category = await _categoryQueryService.Handle(getCategoryByIdQuery);
        var resource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(resource);
    }
    
}