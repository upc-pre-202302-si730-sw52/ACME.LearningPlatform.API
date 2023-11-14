using ACME.LearningPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Components;

namespace ACME.LearningPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;

public static class RequestAuthorizationMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestAuthorization(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestAuthorizationMiddleware>();
    }
}