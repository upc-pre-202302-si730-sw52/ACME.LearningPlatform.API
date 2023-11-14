using ACME.LearningPlatform.API.IAM.Domain.Model.Aggregates;
using ACME.LearningPlatform.API.IAM.Domain.Model.Queries;

namespace ACME.LearningPlatform.API.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
}