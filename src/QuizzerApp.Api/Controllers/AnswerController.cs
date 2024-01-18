using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizzerApp.Application.Features.Commands.Answer.CreateAnswer;
using QuizzerApp.Application.Features.Commands.Answer.CreateAnswerImg;
using QuizzerApp.Application.Features.Commands.Answer.CreateAnswerVote;
using QuizzerApp.Application.Features.Commands.Answer.DeleteAnswerVote;
using QuizzerApp.Application.Features.Queries.Answer.ReadAnswerById;
using QuizzerApp.Application.Features.Queries.Answer.ReadAnswers;

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

        return Ok(res);
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

    [HttpPost("vote")]
    public async Task<IActionResult> AnswerUpVote([FromQuery] CreateAnswerVoteCommand command)
    {
        await _sender.Send(command);
        return StatusCode(201);
    }

    [HttpDelete("vote")]
    public async Task<IActionResult> DeleteAnswerVote([FromQuery] DeleteAnswerVoteCommand command)
    {
        await _sender.Send(command);
        return StatusCode(201);
    }

    [HttpPost("img")]
    public async Task<IActionResult> AddQuestionImage(IFormFile Image, Guid answerId)
    {
        CreateAnswerImgCommand commnad = new(Image, answerId);

        await _sender.Send(commnad);

        return StatusCode(204);
    }


}
