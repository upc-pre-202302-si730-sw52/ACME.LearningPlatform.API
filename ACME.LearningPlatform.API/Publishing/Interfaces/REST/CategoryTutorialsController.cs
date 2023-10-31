using System.Net.Mime;
using ACME.LearningPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningPlatform.API.Publishing.Domain.Services;
using ACME.LearningPlatform.API.Publishing.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ACME.LearningPlatform.API.Publishing.Interfaces.REST;

[ApiController]
[Route("/api/v1/categories/{categoryId}/tutorials")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Categories")]
public class CategoryTutorialsController : ControllerBase
{
    private readonly ITutorialQueryService _tutorialQueryService;

    public CategoryTutorialsController(ITutorialQueryService tutorialQueryService)
    {
        _tutorialQueryService = tutorialQueryService;
    }

    /**
     * Get Tutorials by Category Id.
     * <summary>
     * Get Tutorials for a given category.
     * </summary>
     * <param name="categoryId">Category Id</param>
     * <returns>Tutorial Resources</returns>
     */
    [HttpGet]
    public async Task<IActionResult> GetTutorialsByCategoryId([FromRoute] int categoryId)
    {
        var query = new GetTutorialsByCategoryIdQuery(categoryId);
        var tutorials = await _tutorialQueryService.Handle(query);
        var resources = tutorials.Select(TutorialResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
        
}
