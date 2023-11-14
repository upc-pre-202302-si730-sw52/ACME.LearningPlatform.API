using System.Text.Json.Serialization;

namespace ACME.LearningPlatform.API.IAM.Domain.Model.Aggregates;

/**
 * <summary>
 *     The User Aggregate.
 * </summary>
 * <remarks>
 *     This class is used to represent a user in the system.
 * </remarks>
 */
public class User
{
    public User(string username, string passwordHash)
    {
        Username = username;
        PasswordHash = passwordHash;
    }

    public User()
    {
        Username = string.Empty;
        PasswordHash = string.Empty;
    }

    public int Id { get; }
    public string Username { get; private set; }

    [JsonIgnore] public string PasswordHash { get; private set; }

    /**
     * <summary>
     *     Updates the username of the user.
     * </summary>
     * <param name="username">The new username.</param>
     * <returns>The updated user.</returns>
     */
    public User UpdateUsername(string username)
    {
        Username = username;
        return this;
    }

    /**
     * <summary>
     *     Updates the password hash of the user.
     * </summary>
     * <param name="passwordHash">The new password hash.</param>
     * <returns>The updated user.</returns>
     */
    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }
}