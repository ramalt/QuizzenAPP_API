using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace QuizzerApp.Application.Features.Commands.Answer.CreateAnswerImg;

public record CreateAnswerImgCommand(IFormFile Img, Guid AnswerId) : IRequest;
