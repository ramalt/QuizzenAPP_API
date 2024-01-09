using MediatR;
using QuizzerApp.Application.Dtos.Auth;
using QuizzerApp.Application.Utils;

namespace QuizzerApp.Application.Features.Commands.User.Login;

public record UserLoginCommand(string Email, string Password) : IRequest<TokenDto>;

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, TokenDto>
{
    private readonly TokenProvider _tokenProvider;
    

    public UserLoginCommandHandler(TokenProvider tokenProvider)
    {
        _tokenProvider = tokenProvider;
    }

    public async Task<TokenDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        //check db User
        // Check Pass
        // is confirmed
        // generate token

        return new("134");
    }
}
