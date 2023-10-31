using ACME.LearningPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningPlatform.API.Publishing.Domain.Services;
using ACME.LearningPlatform.API.Publishing.Interfaces.REST.Resources;
using ACME.LearningPlatform.API.Publishing.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ACME.LearningPlatform.API.Publishing.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class TutorialsController : ControllerBase
{
    private readonly ITutorialCommandService _tutorialCommandService;
    private readonly ITutorialQueryService _tutorialQueryService;

    public TutorialsController(ITutorialCommandService tutorialCommandService, ITutorialQueryService tutorialQueryService)
    {
        _tutorialCommandService = tutorialCommandService;
        _tutorialQueryService = tutorialQueryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTutorial([FromBody] CreateTutorialResource createTutorialResource)
    {
        var createTutorialCommand =
            CreateTutorialCommandFromResourceAssembler.ToCommandFromResource(createTutorialResource);
        var tutorial = await _tutorialCommandService.Handle(createTutorialCommand);
        var resource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);
        return CreatedAtAction(nameof(GetTutorialByIdentifier), new { tutorialIdentifier = resource.Id }, resource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllTutorials()
    {
        var getAllTutorialsQuery = new GetAllTutorialsQuery();
        var tutorials = await _tutorialQueryService.Handle(getAllTutorialsQuery);
        var resources = tutorials.Select(TutorialResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{tutorialIdentifier}")]
    public async Task<IActionResult> GetTutorialByIdentifier([FromRoute] int tutorialIdentifier)
    {
        var tutorial = await _tutorialQueryService.Handle(new GetTutorialByIdentifierQuery(tutorialIdentifier));
        if (tutorial == null) return NotFound();
        var resource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);
        return Ok(resource);
    }

    [HttpPost("{tutorialIdentifier}/videos")]
    public async Task<IActionResult> AddVideoToTutorial([FromBody] AddVideoAssetResource addVideoAssetResource,
        [FromRoute] int tutorialIdentifier)
    {
        var addVideAssetToTutorialCommand =
            AddVideoAssetToTutorialCommandFromResourceAssembler.ToCommandFromResource(addVideoAssetResource,
                tutorialIdentifier);
        var tutorial = await _tutorialCommandService.Handle(addVideAssetToTutorialCommand);
        var resource = TutorialResourceFromEntityAssembler.ToResourceFromEntity(tutorial);
        return CreatedAtAction(nameof(GetTutorialByIdentifier), new { tutorialIdentifier = resource.Id }, resource);
    }
}