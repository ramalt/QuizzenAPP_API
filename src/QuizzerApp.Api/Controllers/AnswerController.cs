using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizzerApp.Application.Features.Commands.Answer.CreateAnswer;
using QuizzerApp.Application.Features.Queries.Answer.ReadAnswerById;
using QuizzerApp.Application.Features.Queries.Answer.ReadAnswers;
using QuizzerApp.Application.Features.Queries.Answer.ReadAnswersByQuestionId;
using QuizzerApp.Application.Features.Queries.Answer.ReadAnswersByUserId;

namespace QuizzerApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswerController : ControllerBase
{
    private readonly ISender _sender;

    public AnswerController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAnswer(CreateAnswerCommand command)
    {
        var res = await _sender.Send(command);

        if (res)
            return StatusCode(201);

        throw new Exception();
    }

    [HttpGet]
    public async Task<IActionResult> GetAnswers([FromQuery] string? questionId, string? userId)
    {
        ReadAnswersQuery query = new(QuestionId: questionId, userId: userId);

        var res = await _sender.Send(query);

        return Ok(res);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnswerById([FromRoute] Guid id)
    {
        ReadAnswerByIdQuery query = new(AnswerId: id);

        var res = await _sender.Send(query);

        return Ok(res);

    }


}
