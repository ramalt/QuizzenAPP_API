using MediatR;
using Microsoft.AspNetCore.Identity;
using QuizzenApp.Shared.Exceptions;
using Entity = QuizzenApp.Domain.Entities.UserAggregate;

namespace QuizzerApp.Application.Features.Commands.User.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{

    private readonly UserManager<Entity.User> _userManager;

    public CreateUserCommandHandler(UserManager<Entity.User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var dbUser = await _userManager.FindByEmailAsync(request.Email);

        if (dbUser is not null) throw new AlreadyExistException(request.Email);

        

        Entity.User user = new Entity.User(userName: request.UserName, gender: request.Gender)
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            ExamId = request.ExamId

        };

        var res = await _userManager.CreateAsync(user: user, password: request.Password);

        if (!res.Succeeded)
            throw new IdentityException(res.Errors.Select(e => e.Description).ToList());


        return new string(user.Id);
    }
}
