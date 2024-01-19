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

    public async Task<TokenDto> RefreshTokenAsync(TokenDto tokenDto)
    {
        // Verify the token
        var claimsPrincipal = VerifyToken(tokenDto.Token);

        // Get User Email from token for user verifications
        Claim? emailClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

        // Check user by token email
        var user = await _userManager.FindByEmailAsync(emailClaim.Value);

        if (user is null)
            throw new Exception("user not found with email adress ");

        // Get User refresh Token
        var userRefreshToken = await _userManager.GetAuthenticationTokenAsync(user, "", "refresh_token");

        if (string.IsNullOrEmpty(userRefreshToken))
            throw new Exception("user has not any refresh token yet");


        // Verify the refresh token
        bool correctRefreshToken = string.Equals(userRefreshToken, tokenDto.RefreshToken);

        if (!correctRefreshToken)
            throw new Exception("Wrong refresh token please enter valid refresh token");

        var newToken = await Generate(user);

        return newToken;
    }

    private ClaimsPrincipal VerifyToken(string token)
    {
        JwtSecurityTokenHandler _tokenHandler = new();

        var jwtSettings = _configuration.GetSection("JwtSettings");

        var tokenValidationParams = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["issuer"],
            ValidAudience = jwtSettings["audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["secret"])),
            RequireExpirationTime = true
        };

        ClaimsPrincipal? principal = _tokenHandler.ValidateToken(token: token, validationParameters: tokenValidationParams, out SecurityToken securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("invalid token.");

        return principal;
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
