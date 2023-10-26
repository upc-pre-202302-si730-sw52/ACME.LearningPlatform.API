using ACME.LearningPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningPlatform.API.Publishing.Interfaces.REST.Resources;

namespace ACME.LearningPlatform.API.Publishing.Interfaces.REST.Transform;

public static class CreateTutorialCommandFromResourceAssembler
{
    public static CreateTutorialCommand ToCommandFromResource(CreateTutorialResource resource)
    {
        return new CreateTutorialCommand(resource.Title, resource.Summary, resource.CategoryIdentifier);
    }
}