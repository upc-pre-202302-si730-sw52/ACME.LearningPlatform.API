using ACME.LearningPlatform.API.Publishing.Domain.Model.Aggregates;
using ACME.LearningPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningPlatform.API.Publishing.Domain.Repositories;

public interface ITutorialRepository: IBaseRepository<Tutorial>
{
}