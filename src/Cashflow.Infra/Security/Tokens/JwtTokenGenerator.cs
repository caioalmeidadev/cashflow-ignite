using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cashflow.Domain.Entities;
using Cashflow.Domain.Security.Tokens;
using Microsoft.IdentityModel.Tokens;

namespace Cashflow.Infra.Security.Tokens;

public class JwtTokenGenerator:IAccessTokenGenerator
{
    private readonly uint _expirationTimeInMinutes;
    private readonly string _secretKey;

    public JwtTokenGenerator(uint expirationTimeInMinutes, string secretKey)
    {
        _expirationTimeInMinutes = expirationTimeInMinutes;
        _secretKey = secretKey;
    }
    
    
    public string Generate(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Sid, user.Identifier.ToString()),
        };
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddMinutes(_expirationTimeInMinutes),
            SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature),
            Subject = new ClaimsIdentity(claims)
            
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        
        var secureToken = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(secureToken);
        
    }
    
    private SymmetricSecurityKey GetSymmetricSecurityKey() => new(Encoding.UTF8.GetBytes(_secretKey));
    
}


