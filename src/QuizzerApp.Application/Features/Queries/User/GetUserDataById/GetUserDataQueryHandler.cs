using MediatR;
using Microsoft.AspNetCore.Identity;
using Model = QuizzenApp.Domain.Entities.UserAggregate;
using QuizzerApp.Application.Dtos.User;
using QuizzerApp.Application.Common.Interfaces;
using QuizzenApp.Shared.Exceptions;

namespace QuizzerApp.Application.Features.Queries.User.GetUserDataById;

public class GetUserDataQueryHandler : IRequestHandler<GetUserDataQuery, UserDataDto>
{
    private readonly UserManager<Model.User> _userManager;
    private readonly IRepositoryManager _manager;

    public GetUserDataQueryHandler(UserManager<Model.User> userManager, IRepositoryManager manager)
    {
        _userManager = userManager;
        _manager = manager;
    }

    public async Task<UserDataDto> Handle(GetUserDataQuery request, CancellationToken cancellationToken)
    {
        Model.User? dbUser = await _userManager.FindByIdAsync(request.Id);

        if (dbUser is null) throw new NotFoundException("User", request.Id);

        var exam = await _manager.User.GetUserExamAsync(dbUser.ExamId);


        var res = new UserDataDto(Id: dbUser.Id,
                               FirstName: dbUser.FirstName,
                               LastName: dbUser.LastName,
                               UserName: dbUser.UserName,
                               Exam: exam.Name,
                               Email: dbUser.Email,
                               ProfileImg: dbUser.ProfileImg ?? null);


        return res;
    }
}
