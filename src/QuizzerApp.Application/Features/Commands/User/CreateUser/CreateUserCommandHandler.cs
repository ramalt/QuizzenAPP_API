using MediatR;
using Microsoft.AspNetCore.Identity;
using QuizzenApp.Shared.Dto;
using Entity = QuizzenApp.Domain.Entities.UserAggregate;

namespace QuizzerApp.Application.Features.Commands.User.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<string>>
{

    private readonly UserManager<Entity.User> _userManager;

    public CreateUserCommandHandler(UserManager<Entity.User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Response<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        //TODO: Check is user exist?
        
        Entity.User user = new Entity.User(userName: request.UserName, gender: request.Gender)
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            ExamId = request.ExamId

        };

        var res = await _userManager.CreateAsync(user: user, password: request.Password);

        if (!res.Succeeded)
            throw new Exception("WTF, user creation exception");


        return new Response<string>(user.Id);
    }
}
