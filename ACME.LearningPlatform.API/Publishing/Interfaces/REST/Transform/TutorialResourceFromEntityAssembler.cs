using ACME.LearningPlatform.API.Publishing.Domain.Model.Aggregates;
using ACME.LearningPlatform.API.Publishing.Interfaces.REST.Resources;

namespace ACME.LearningPlatform.API.Publishing.Interfaces.REST.Transform;

public static class TutorialResourceFromEntityAssembler
{
    public static TutorialResource ToResourceFromEntity(Tutorial tutorial)
    {
        return new TutorialResource(tutorial.Id, tutorial.Title, tutorial.Summary);
    }
}