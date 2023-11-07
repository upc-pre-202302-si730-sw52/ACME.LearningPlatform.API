using ACME.LearningPlatform.API.IAM.Application.Internal.OutboundServices;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ACME.LearningPlatform.API.IAM.Infrastructure.Hashing.Services;

/**
 * Hashing service.
 * <summary>
 * This class is used to hash passwords and verify them.
 * </summary>
 */
public class HashingService : IHashingService
{
    /**
     * Hashes a password.
     * <param name="password">The original password</param>
     * <returns>The hashed password</returns>
     */
    public string HashPassword(string password)
    {
        return BCryptNet.HashPassword(password);
    }

    /**
     * Verifies a password.
     * <param name="password">The original password</param>
     * <param name="passwordHash">The hashed password</param>
     * <returns>True if the password is valid, false otherwise</returns>
     */
    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCryptNet.Verify(password, passwordHash);
    }
}