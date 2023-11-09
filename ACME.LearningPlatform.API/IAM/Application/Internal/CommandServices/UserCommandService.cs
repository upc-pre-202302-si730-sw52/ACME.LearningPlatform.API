using ACME.LearningPlatform.API.IAM.Application.Internal.OutboundServices;
using ACME.LearningPlatform.API.IAM.Domain.Model.Aggregates;
using ACME.LearningPlatform.API.IAM.Domain.Model.Commands;
using ACME.LearningPlatform.API.IAM.Domain.Repositories;
using ACME.LearningPlatform.API.IAM.Domain.Services;
using ACME.LearningPlatform.API.Shared.Domain.Repositories;

namespace ACME.LearningPlatform.API.IAM.Application.Internal.CommandServices;

/**
 * User Command Service.
 * <summary>
 *   <para>
 *     This class is responsible for handling the commands related to the User aggregate.
 *   </para>
 * </summary>
 */
public class UserCommandService : IUserCommandService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IHashingService _hashingService;
    private readonly IUnitOfWork _unitOfWork;

    public UserCommandService(IUserRepository userRepository, ITokenService tokenService, IHashingService hashingService, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _hashingService = hashingService;
        _unitOfWork = unitOfWork;
    }

    /**
     * Handle the SignUpCommand.
     * <summary>
     *   <para>
     *     This method is responsible for handling the SignUpCommand.
     *   </para>
     * </summary>
     * <param name="command">The SignUpCommand to be handled, including username and password.</param>
     * <returns>A Task if successful, otherwise throws and exception.</returns>
     */
    public async Task Handle(SignUpCommand command)
    {
        if (_userRepository.ExistsByUsername(command.Username))
            throw new Exception($"Username {command.Username} is already taken");

        var hashedPassword = _hashingService.HashPassword(command.Password);
        var user = new User(command.Username, hashedPassword);
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Error while creating user: {e.Message}");
        }

    }

    /**
     * Handle the SignInCommand.
     * <summary>
     *   <para>
     *     This method is responsible for handling the SignInCommand.
     *   </para>
     * </summary>
     * <param name="command">The SignInCommand to be handled, including username and password.</param>
     * <returns>A tuple containing the User and the generated token if successful, otherwise throws and exception.</returns>
     */
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await _userRepository.FindByUsernameAsync(command.Username);

        if (user == null || !_hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid username or password");

        var token = _tokenService.GenerateToken(user);

        return (user, token);
    }
}