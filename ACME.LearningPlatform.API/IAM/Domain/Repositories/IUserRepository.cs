using ACME.LearningPlatform.API.IAM.Domain.Model.Aggregates;
using ACME.LearningPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningPlatform.API.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
}