namespace ACME.LearningPlatform.API.IAM.Application.Internal.OutboundServices;

/**
 * Hashing service.
 * <summary>
 *     This interface is used to hash passwords and verify them.
 * </summary>
 */
public interface IHashingService
{
    /**
     * Hashes a password.
     * <param name="password">The original password</param>
     * <returns>The hashed password</returns>
     */
    string HashPassword(string password);

    /**
     * Verifies a password.
     * <param name="password">The original password</param>
     * <param name="passwordHash">The hashed password</param>
     * <returns>True if the password is valid, false otherwise</returns>
     */
    bool VerifyPassword(string password, string passwordHash);
}