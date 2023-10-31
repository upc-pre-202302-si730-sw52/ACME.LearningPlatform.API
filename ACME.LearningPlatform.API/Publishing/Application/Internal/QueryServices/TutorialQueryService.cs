using ACME.LearningPlatform.API.Publishing.Domain.Model.Aggregates;
using ACME.LearningPlatform.API.Publishing.Domain.Model.Queries;
using ACME.LearningPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningPlatform.API.Publishing.Domain.Services;

namespace ACME.LearningPlatform.API.Publishing.Application.Internal.QueryServices;

public class TutorialQueryService: ITutorialQueryService
{
    private readonly ITutorialRepository _tutorialRepository;

    public TutorialQueryService(ITutorialRepository tutorialRepository)
    {
        _tutorialRepository = tutorialRepository;
    }

    public async Task<Tutorial?> Handle(GetTutorialByIdentifierQuery query)
    {
        return await _tutorialRepository.FindByIdAsync(query.tutorialId);
    }

    public async Task<IEnumerable<Tutorial>> Handle(GetAllTutorialsQuery query)
    {
        return await _tutorialRepository.ListAsync();
    }
}