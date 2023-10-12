using ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningPlatform.API.Shared.Infrastructure.Configuration;
using ACME.LearningPlatform.API.Shared.Infrastructure.Repositories;

namespace ACME.LearningPlatform.API.Publishing.Infrastructure.Repositories;

public class CategoryRepository: BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}