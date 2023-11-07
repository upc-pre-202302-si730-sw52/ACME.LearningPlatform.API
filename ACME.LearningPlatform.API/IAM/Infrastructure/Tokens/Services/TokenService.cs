using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ACME.LearningPlatform.API.IAM.Application.Internal.OutboundServices;
using ACME.LearningPlatform.API.IAM.Domain.Model.Aggregates;
using ACME.LearningPlatform.API.IAM.Infrastructure.Tokens.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ACME.LearningPlatform.API.IAM.Infrastructure.Tokens.Services;

public class TokenService : ITokenService
{
    private readonly EncodingSettings _encodingSettings;

    public TokenService(IOptions<EncodingSettings> encodingSettings)
    {
        _encodingSettings = encodingSettings.Value;
    }

    public string GenerateToken(User user)
    {
        var secret = _encodingSettings.Secret;
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

    public int? ValidateToken(string token)
    {
        throw new NotImplementedException();
    }
}