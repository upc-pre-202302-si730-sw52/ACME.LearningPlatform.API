using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ACME.LearningPlatform.API.IAM.Application.Internal.OutboundServices;
using ACME.LearningPlatform.API.IAM.Domain.Model.Aggregates;
using ACME.LearningPlatform.API.IAM.Infrastructure.Tokens.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ACME.LearningPlatform.API.IAM.Infrastructure.Tokens.Services;

/**
 * <summary>
 *  This class is responsible for generating and validating tokens.
 * </summary>
 */
public class TokenService : ITokenService
{
    private readonly TokenSettings _tokenSettings;

    public TokenService(IOptions<TokenSettings> encodingSettings)
    {
        _tokenSettings = encodingSettings.Value;
    }

    /**
     * <summary>
     *  This method generates a token for a given user.
     * </summary>
     * <param name="user">The user to generate the token for.</param>
     * <returns>The generated token.</returns>
     */
    public string GenerateToken(User user)
    {
        var secret = _tokenSettings.Secret;
        var key = Encoding.ASCII.GetBytes(secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);

    }

    /**
     * <summary>
     *  This method validates a token.
     * </summary>
     * <param name="token">The token to validate.</param>
     * <returns>The user id if the token is valid, null otherwise.</returns>
     */
    public int? ValidateToken(string token)
    {

        if (string.IsNullOrEmpty(token))
            return null;
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_tokenSettings.Secret);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(claim => claim.Type.Equals(ClaimTypes.Sid)).Value);
            return userId;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
}