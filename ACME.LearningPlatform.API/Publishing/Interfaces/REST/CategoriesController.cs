using System.Net.Mime;
using ACME.LearningPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningPlatform.API.Publishing.Domain.Services;
using ACME.LearningPlatform.API.Publishing.Interfaces.REST.Resources;
using ACME.LearningPlatform.API.Publishing.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ACME.LearningPlatform.API.Publishing.Interfaces.REST;

/**
 * Categories Controller
 * <summary>
 *    This controller is responsible for handling all the requests related to categories.
 * </summary>
 */

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CategoriesController: ControllerBase
{
    private readonly ICategoryCommandService _categoryCommandService;
    private readonly ICategoryQueryService _categoryQueryService;

    public CategoriesController(ICategoryCommandService categoryCommandService, ICategoryQueryService categoryQueryService)
    {
        _categoryCommandService = categoryCommandService;
        _categoryQueryService = categoryQueryService;
    }

    /**
     * Create Category.
     * <summary>
     *  This method is responsible for handling the request to create a new category.
     * </summary>
     * <param name="createCategoryResource">The resource containing the information to create a new category.</param>
     * <returns>The newly created category resource.</returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a category", 
        Description = "Creates a category with a given name",
        OperationId = "CreateCategory")]
    [SwaggerResponse(201, "The category was created", typeof(CategoryResource))]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryResource createCategoryResource)
    {
        var createCategoryCommand = CreateCategoryCommandFromResourceAssembler.ToCommandFromResource(createCategoryResource);
        var category = await _categoryCommandService.Handle(createCategoryCommand);
        var resource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return CreatedAtAction(nameof(GetCategoryById), new { id = resource.Id }, resource);
    }

    /**
     * Get Category By Id.
     * <summary>
     *  This method is responsible for handling the request to get a category by its id.
     * </summary>
     * <param name="id">The category identifier.</param>
     * <returns>The category resource.</returns>
     */
    [HttpGet("{id:int}")]
    [SwaggerOperation(
        Summary = "Gets a category by id", 
        Description = "Gets a category for a given identifier",
        OperationId = "GetCategoryById")]
    [SwaggerResponse(200, "The category was found", typeof(CategoryResource))]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var getCategoryByIdQuery = new GetCategoryByIdQuery(id);
        var category = await _categoryQueryService.Handle(getCategoryByIdQuery);
        var resource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(resource);
    }
    
}