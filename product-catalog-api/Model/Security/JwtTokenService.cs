using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using product_catalog_data_model.Model.Security;

namespace product_catalog_api.Model.Security;

/// <inheritdoc />
public class JwtTokenService : ITokenService
{
    private const string Issuer = ConstantsStore.JwtConstants.TokenIssuer;

    private const string Secret = ConstantsStore.JwtConstants.TokenSecret;

    /// <inheritdoc />
    public Task<string> GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Convert.FromBase64String(Secret);

        var claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) });
        var signingCredentials =
            new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Issuer = Issuer,
            Audience = Issuer,
            Expires = DateTime.Now.AddMinutes(15),
            SigningCredentials = signingCredentials
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Task.FromResult(tokenHandler.WriteToken(token));
    }
}
