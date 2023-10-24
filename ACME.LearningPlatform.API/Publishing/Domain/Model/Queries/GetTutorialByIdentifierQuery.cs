using ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;

namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Queries;

public record GetTutorialByIdentifierQuery(int tutorialId);