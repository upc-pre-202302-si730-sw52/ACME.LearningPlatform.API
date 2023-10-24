using ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;

namespace ACME.LearningPlatform.API.Publishing.Domain.Model.Commands;

public record AddVideoAssetToTutorialCommand(string VideoUrl, int TutorialId);