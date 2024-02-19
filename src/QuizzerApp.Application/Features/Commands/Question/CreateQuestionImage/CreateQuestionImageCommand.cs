using MediatR;
using Microsoft.AspNetCore.Http;

namespace QuizzerApp.Application.Features.Commands.Question.CreateQuestionImage;

public record CreateQuestionImageCommand(IFormFile Img, Guid QuestionId) : IRequest;


