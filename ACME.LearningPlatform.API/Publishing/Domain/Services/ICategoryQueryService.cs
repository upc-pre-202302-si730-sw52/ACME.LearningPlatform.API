using ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningPlatform.API.Publishing.Domain.Model.Queries;

namespace ACME.LearningPlatform.API.Publishing.Domain.Services;

public interface ICategoryQueryService
{
    Task<Category> Handle(GetCategoryByIdQuery query);
}