using ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningPlatform.API.Shared.Infrastructure.Persistence.Configuration;
using ACME.LearningPlatform.API.Shared.Infrastructure.Persistence.Repositories;

namespace ACME.LearningPlatform.API.Publishing.Infrastructure.Persistence.Repositories;

public class CategoryRepository: BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}