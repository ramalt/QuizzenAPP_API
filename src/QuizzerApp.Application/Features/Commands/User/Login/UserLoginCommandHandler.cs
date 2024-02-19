using MediatR;
using Microsoft.AspNetCore.Identity;
using QuizzenApp.Shared.Exceptions;
using QuizzerApp.Application.Dtos.Auth;
using QuizzerApp.Application.Utils;
using Model = QuizzenApp.Domain.Entities.UserAggregate;

namespace QuizzerApp.Application.Features.Commands.User.Login;

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, TokenDto>
{
    private readonly TokenProvider _tokenProvider;
    private readonly UserManager<Model.User> _manager;


    public UserLoginCommandHandler(TokenProvider tokenProvider, UserManager<Model.User> manager)
    {
        _tokenProvider = tokenProvider;
        _manager = manager;
    }

    public async Task<TokenDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        //check db User
        var dbUser = await _manager.FindByEmailAsync(request.Email);

        if (dbUser is null)
            throw new NotFoundException("user", request.Email);
        // Check Pass
        bool isPasswordCorrect = await _manager.CheckPasswordAsync(dbUser, request.Password);

        if (!isPasswordCorrect)
            throw new WrongSigninCredentialsException();
        // is confirmed


        // generate token
        var token = await _tokenProvider.Generate(dbUser);

        return token;
    }
}
