using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizzerApp.Application.Features.Commands.Question;
using QuizzerApp.Application.Features.Queries.Question.ReadQuestionById;
using QuizzerApp.Application.Features.Queries.Question.ReadQuestionByUserId;

namespace QuizzerApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    private readonly ISender _sender;

    public QuestionController(ISender sender)
    {
        _sender = sender;
    }


    [HttpPost]
    public async Task<ActionResult> CreateQuestion(CreateQuestionCommand command)
    {

        var res = await _sender.Send(command);

        if (res)
            return StatusCode(201);

        throw new Exception();


    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetQuestionById([FromRoute] Guid id)
    {
        ReadQuestionByIdQuery query = new(QuestionId: id);
        var res = await _sender.Send(query);

        return Ok(res);

    }


    [HttpGet("u/{userId}")]
    public async Task<ActionResult> GetQuestionByUserId([FromRoute] string userId)
    {
        ReadQuestionsByUserIdQuery query = new(UserId: userId);
        var res = await _sender.Send(query);

        return Ok(res);

    }


}
