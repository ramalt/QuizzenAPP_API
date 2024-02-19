using MediatR;
using QuizzerApp.Application.Dtos.Auth;
using QuizzerApp.Application.Utils;

namespace QuizzerApp.Application.Features.Commands.User.GetNewToken;

public record GetNewTokenCommand(string Token, string RefreshToken) : IRequest<TokenDto>;

public class GetNewTokenCommandHandler : IRequestHandler<GetNewTokenCommand, TokenDto>
{
    private readonly TokenProvider _tokenProvider;


    public GetNewTokenCommandHandler(TokenProvider tokenProvider)
    {
        _tokenProvider = tokenProvider;
    }

    public async Task<TokenDto> Handle(GetNewTokenCommand request, CancellationToken cancellationToken)
    {
        
        TokenDto tokenDto = new(request.Token, request.RefreshToken);
        var res = await _tokenProvider.RefreshTokenAsync(tokenDto);

        return res;
    }
}
