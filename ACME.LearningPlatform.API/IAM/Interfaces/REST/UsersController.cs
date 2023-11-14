using System.Net.Mime;
using ACME.LearningPlatform.API.IAM.Domain.Model.Queries;
using ACME.LearningPlatform.API.IAM.Domain.Services;
using ACME.LearningPlatform.API.IAM.Interfaces.REST.Resources;
using ACME.LearningPlatform.API.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ACME.LearningPlatform.API.IAM.Interfaces.REST;

/**
 * Users Controller.
 * <summary>
 *     This controller is responsible for handling the requests related to the user.
 * </summary>
 */
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UsersController : ControllerBase
{
    private readonly IUserQueryService _userQueryService;

    public UsersController(IUserQueryService userQueryService)
    {
        _userQueryService = userQueryService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);
        var user = await _userQueryService.Handle(getUserByIdQuery);
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user!);
        return Ok(userResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await _userQueryService.Handle(getAllUsersQuery);
        var userResources = users
            .Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }

}