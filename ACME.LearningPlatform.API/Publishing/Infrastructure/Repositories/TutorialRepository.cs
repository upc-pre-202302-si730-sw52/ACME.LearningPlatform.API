using ACME.LearningPlatform.API.Publishing.Domain.Model.Aggregates;
using ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningPlatform.API.Shared.Infrastructure.Configuration;
using ACME.LearningPlatform.API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACME.LearningPlatform.API.Publishing.Infrastructure.Repositories;

public class TutorialRepository: BaseRepository<Tutorial>, ITutorialRepository 
{
    public TutorialRepository(AppDbContext context) : base(context)
    {
    }
}