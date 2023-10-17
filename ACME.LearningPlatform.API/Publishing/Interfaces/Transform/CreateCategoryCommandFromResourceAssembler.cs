using ACME.LearningPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningPlatform.API.Publishing.Interfaces.REST.Resources;

namespace ACME.LearningPlatform.API.Publishing.Interfaces.Transform;

public class CreateCategoryCommandFromResourceAssembler
{
    public static CreateCategoryCommand ToCommandFromResource(CreateCategoryResource resource)
    {
        return new CreateCategoryCommand(
            resource.Name);
    }
}