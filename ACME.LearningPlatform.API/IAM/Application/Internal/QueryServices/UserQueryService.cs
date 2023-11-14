using ACME.LearningPlatform.API.IAM.Domain.Model.Aggregates;
using ACME.LearningPlatform.API.IAM.Domain.Model.Queries;
using ACME.LearningPlatform.API.IAM.Domain.Repositories;
using ACME.LearningPlatform.API.IAM.Domain.Services;

namespace ACME.LearningPlatform.API.IAM.Application.Internal.QueryServices;

public class UserQueryService : IUserQueryService
{
    private readonly IUserRepository _userRepository;

    public UserQueryService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await _userRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await _userRepository.ListAsync();
    }
}