using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuizzenApp.Domain.Entities.UserAggregate;
using QuizzerApp.Application.Dtos.Auth;

namespace QuizzerApp.Application.Utils;

public class TokenProvider
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;

    public TokenProvider(IConfiguration configuration, UserManager<User> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }

    public async Task<TokenDto> Generate(User user)
    {
        var signinCredentials = GetSinginCredentials();
        var claims = await GetUserClaims(user);
        var tokenOptions = GenerateTokenOption(claims, signinCredentials);
        var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        string refreshToken = GenerateRefreshToken();

        var dbUserToken = await _userManager.GetAuthenticationTokenAsync(user, "", "refresh_token");
        if (!string.IsNullOrEmpty(dbUserToken))
            await _userManager.RemoveAuthenticationTokenAsync(user, "", "refresh_token");

        await _userManager.SetAuthenticationTokenAsync(user, "", "refresh_token", refreshToken);

        return new(Token: accessToken, RefreshToken: refreshToken);
    }

    private string GenerateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }

    private async Task<List<Claim>> GetUserClaims(User user)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("examId", user.ExamId.ToString())
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
