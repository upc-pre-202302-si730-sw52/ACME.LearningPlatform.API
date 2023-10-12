using ACME.LearningPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;

namespace ACME.LearningPlatform.API.Publishing.Domain.Services;

public interface ICategoryCommandService
{
    Task<Category> Handle(CreateCategoryCommand command);
}