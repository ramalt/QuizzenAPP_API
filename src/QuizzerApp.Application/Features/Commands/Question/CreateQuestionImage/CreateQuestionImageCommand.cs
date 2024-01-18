using MediatR;
using Microsoft.AspNetCore.Http;
using QuizzenApp.PhotoStock.Services;
using QuizzerApp.Application.Common.Interfaces;

namespace QuizzerApp.Application.Features.Commands.Question.CreateQuestionImage;

public record CreateQuestionImageCommand(IFormFile Img, Guid QuestionId) : IRequest;


