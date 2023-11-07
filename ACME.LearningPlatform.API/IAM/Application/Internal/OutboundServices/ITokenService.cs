using ACME.LearningPlatform.API.IAM.Domain.Model.Aggregates;

namespace ACME.LearningPlatform.API.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    int? ValidateToken(string token);
}