using ACME.LearningPlatform.API.IAM.Domain.Model.Aggregates;
using ACME.LearningPlatform.API.IAM.Domain.Model.Commands;

namespace ACME.LearningPlatform.API.IAM.Domain.Services;

/**
 * This interface is used to define the contract for the UserCommandService.
 * The UserCommandService is responsible for handling the commands that are
 * sent to the User aggregate.
 */
public interface IUserCommandService
{
    /**
     * This method is used to handle the SignUpCommand.
     * The SignUpCommand is used to create a new User.
     * 
     * @param command The SignUpCommand that is sent to the UserCommandService.
     * @return A Task that represents the asynchronous operation.
     */
    Task Handle(SignUpCommand command);
    
    /**
     * This method is used to handle the SignInCommand.
     * The SignInCommand is used to sign in a User.
     * 
     * @param command The SignInCommand that is sent to the UserCommandService.
     * @return A Task that represents the asynchronous operation.
     */
    Task<(User user, string token)> Handle(SignInCommand command);
}