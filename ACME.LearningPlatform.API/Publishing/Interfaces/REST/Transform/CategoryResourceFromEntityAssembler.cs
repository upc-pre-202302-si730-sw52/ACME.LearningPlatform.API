using ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningPlatform.API.Publishing.Interfaces.REST.Resources;

namespace ACME.LearningPlatform.API.Publishing.Interfaces.REST.Transform;

public static class CategoryResourceFromEntityAssembler
{
    public static CategoryResource ToResourceFromEntity(Category entity)
    {
        return new CategoryResource(
            entity.Id,
            entity.Name);
    }
}