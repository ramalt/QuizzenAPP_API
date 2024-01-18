using MediatR;
using Microsoft.AspNetCore.Http;

namespace QuizzerApp.Application.Features.Commands.User.CreateUserImage;

public record CreateUserImageCommand(IFormFile Img, string UserId) : IRequest;
