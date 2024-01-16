using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizzerApp.Application.Common.Interfaces;
using QuizzerApp.Application.Dtos.Exam;
using QuizzerApp.Application.Dtos.Image;
using QuizzerApp.Application.Dtos.Question;
using QuizzerApp.Application.Dtos.User;

namespace QuizzerApp.Application.Features.Queries.Question.ReadQuestions;

public class ReadQuestionQueryHandler : IRequestHandler<ReadQuestionQuery, List<QuestionDto>>
{
    private readonly IRepositoryManager _manager;

    public ReadQuestionQueryHandler(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public async Task<List<QuestionDto>> Handle(ReadQuestionQuery request, CancellationToken cancellationToken)
    {
        var query = _manager.Question.GetQueriable();

        if (!string.IsNullOrEmpty(request.Exam))
            query = query.Where(q => string.Equals(q.Exam.Name, request.Exam));

        if (!string.IsNullOrEmpty(request.Subject))
            query = query.Where(q => string.Equals(q.Subject.Name, request.Subject));

        if (!string.IsNullOrEmpty(request.Topic))
            query = query.Where(q => string.Equals(q.Topic.Name, request.Topic));

        if (!string.IsNullOrEmpty(request.UserId))
            query = query.Where(q => string.Equals(q.UserId, request.UserId));


        var questions = await query.Include(q => q.User)
                                   .Include(q => q.Exam)
                                   .Include(q => q.Subject)
                                   .Include(q => q.Topic)
                                   .ToListAsync(cancellationToken: cancellationToken);


        return questions.Select(q => new QuestionDto
        (
            Id: q.Id,
            Title: q.Title,
            Description: q.Description,
            Status: q.Status.ToString(),
            User: new UserDto(q.UserId, q.User.UserName, q.User.FirstName, q.User.LastName,
            profileImg: q.User.ProfileImg),
            Images: _manager.Photo.GetDbQuestionImgPaths(q.Id.Value)
                        .Select(img => new ImageDto(img.ImgPath))
                        .ToList(),
            Tags: new ExamDto(q.Exam.Name, q.Subject.Name, q.Topic.Name),
            CreatedDate: q.CreatedDate
        )).ToList();

    }
}