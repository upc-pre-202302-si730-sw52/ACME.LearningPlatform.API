using ACME.LearningPlatform.API.Publishing.Domain.Model.Aggregates;
using ACME.LearningPlatform.API.Publishing.Domain.Model.Commands;

namespace ACME.LearningPlatform.API.Publishing.Domain.Services;

public interface ITutorialCommandService
{
    Task<Tutorial> Handle(AddVideoAssetToTutorialCommand command);
    Task<Tutorial> Handle(CreateTutorialCommand command);
}