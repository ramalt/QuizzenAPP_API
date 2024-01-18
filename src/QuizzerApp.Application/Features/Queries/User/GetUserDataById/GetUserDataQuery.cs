using MediatR;
using QuizzerApp.Application.Dtos.User;
using QuizzenApp.Shared.Dto;

namespace QuizzerApp.Application.Features.Queries.User.GetUserDataById;

public record GetUserDataQuery(string Id) : IRequest<Response<UserDataDto>>;
