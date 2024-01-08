using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizzerApp.Application.Features.Commands.Answer.CreateAnswer;
using QuizzerApp.Application.Features.Queries.Answer.ReadAnswersByQuestionId;

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

    [HttpGet("{questionId}")]
    public async Task<IActionResult> GetAnswersByQuestion(Guid questionId)
    {
        ReadAnsersByQuestionIdQuery query = new(QuestionId: questionId);

        var res = await _sender.Send(query);

        return Ok(res);

    }

}
