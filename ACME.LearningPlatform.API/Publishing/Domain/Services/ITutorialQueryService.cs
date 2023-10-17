using ACME.LearningPlatform.API.Publishing.Domain.Model.Aggregates;
using ACME.LearningPlatform.API.Publishing.Domain.Model.Queries;

namespace ACME.LearningPlatform.API.Publishing.Domain.Services;

public interface ITutorialQueryService
{
    Task<Tutorial?> Handle(GetTutorialByIdentifierQuery query);
}