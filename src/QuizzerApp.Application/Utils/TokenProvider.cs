using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuizzenApp.Domain.Entities.UserAggregate;
using QuizzerApp.Application.Dtos.Auth;

namespace QuizzerApp.Application.Utils;

public class TokenProvider
{
    private readonly IConfiguration _configuration;

    public TokenProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }



        public async Task<TokenDto> Generate(User user)
    {
        var signinCredentials = GetSinginCredentials();
        var claims = await GetUserClaims(user);
        var tokenOptions = GenerateTokenOption(claims, signinCredentials);
        var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        // string refreshToken = GenerateRefreshToken();
        // user.RefreshToken = refreshToken;
        // user.RefreshTokenExpireDate = DateTime.Now.AddDays(14);

        // await _userManager.UpdateAsync(user);

        return new(accessToken);

    }

    private async Task<List<Claim>> GetUserClaims(User user)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
        };

        return claims;
    }

    private SigningCredentials GetSinginCredentials()
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["secret"]));
        return new(key: key, SecurityAlgorithms.HmacSha256);
    }

    private JwtSecurityToken GenerateTokenOption(List<Claim> claims, SigningCredentials credentials)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");

        return new JwtSecurityToken(
            issuer: jwtSettings["issuer"],
            audience: jwtSettings["audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToInt32(jwtSettings["expires"])),
            signingCredentials: credentials
        );
    }
}
