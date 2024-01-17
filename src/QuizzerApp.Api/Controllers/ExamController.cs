using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizzerApp.Application.Features.Queries.Exam.GetSubjects;
using QuizzerApp.Application.Features.Queries.Exam.GetTopics;

namespace QuizzerApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExamController : ControllerBase
{
    private readonly ISender _sender;

    public ExamController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("subject")]
    public async Task<IActionResult> GetSubjects([FromQuery][Required] Guid e)
    {
        GetSubjectsByExamIdQuery query = new(e);

        var res = await _sender.Send(query);

        return Ok(res);
    }

    [HttpGet("topic")]
    public async Task<IActionResult> GetTopics([FromQuery][Required] Guid s)
    {
        GetTopicsBySubjectIdQuery query = new(s);

        var res = await _sender.Send(query);

        return Ok(res);
    }
}
