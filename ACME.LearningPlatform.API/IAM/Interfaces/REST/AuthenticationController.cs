using System.Net.Mime;
using ACME.LearningPlatform.API.IAM.Domain.Services;
using ACME.LearningPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using ACME.LearningPlatform.API.IAM.Interfaces.REST.Resources;
using ACME.LearningPlatform.API.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ACME.LearningPlatform.API.IAM.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AuthenticationController : ControllerBase
{
    private readonly IUserCommandService _userCommandService;

    public AuthenticationController(IUserCommandService userCommandService)
    {
        _userCommandService = userCommandService;
    }
    
    /**
 * Sign up.
 * <summary>
 *     This endpoint is responsible for creating a new user.
 * </summary>
 * <param name="signUpResource">The sign up resource containing the username and password.</param>
 * <returns>A confirmation message if successful.</returns>
 */
    
    [HttpPost("sign-up")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUp([FromBody] SignUpResource signUpResource)
    {
        var signUpCommand = SignUpCommandFromResourceAssembler.ToCommandFromResource(signUpResource);
        await _userCommandService.Handle(signUpCommand);
        return Ok("User created successfully");
    }

    /**
     * Sign in.
     * <summary>
     *     This endpoint is responsible for authenticating a user.
     * </summary>
     * <param name="signInResource">The sign in resource containing the username and password.</param>
     * <returns>The authenticated user including a JWT token.</returns>
     */
    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInResource signInResource)
    {
        var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(signInResource);
        var authenticatedUser = await _userCommandService.Handle(signInCommand);
        var resource =
            AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(authenticatedUser.user,
                authenticatedUser.token);
        return Ok(resource);
    }
}