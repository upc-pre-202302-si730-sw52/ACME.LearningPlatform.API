namespace ACME.LearningPlatform.API.Publishing.Interfaces.REST.Resources;

public record CreateTutorialResource(string Title, string Summary, int CategoryIdentifier);