using MediatR;
using Microsoft.AspNetCore.Identity;
using Entity = QuizzenApp.Domain.Entities.UserAggregate;

namespace QuizzerApp.Application.Features.Commands.User.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{

    private readonly UserManager<Entity.User> _userManager;

    public CreateUserCommandHandler(UserManager<Entity.User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Entity.User user = new Entity.User(userName: request.userName, gender: request.gender)
        {
            Email = request.email,
        };

        var res = await _userManager.CreateAsync(user: user, password: request.password);
        if (!res.Succeeded)
            throw new Exception("WTF, user creation exception");


        return true;
    }
}
