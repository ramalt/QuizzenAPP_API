using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;
using QuizzerApp.Application.Common.Interfaces;
using QuizzerApp.Application.Dtos.Answer;
using QuizzerApp.Application.Dtos.User;

namespace QuizzerApp.Application.Features.Queries.Answer.ReadAnswersByQuestionId;

// public class ReadAnswerByQuestionIdQueryHandler : IRequestHandler<ReadAnsersByQuestionIdQuery, List<AnswerDto>>
// {
//     private readonly IRepositoryManager _manager;

//     public ReadAnswerByQuestionIdQueryHandler(IRepositoryManager manager)
//     {
//         _manager = manager;
//     }

//     public async Task<List<AnswerDto>> Handle(ReadAnsersByQuestionIdQuery request, CancellationToken cancellationToken)
//     {

//         var query = _manager.Answer.GetQueriable();

//         var questionAnswers = await query.Include(qa => qa.User)
//                                          .Where(qa => qa.QuestionId == new QuestionId(request.QuestionId))
//                                          .ToListAsync(cancellationToken);

//         List<AnswerDto> res = new();
//         questionAnswers.ForEach(qa =>
//         {
//             res.Add(new AnswerDto(
//                 Id: qa.Id,
//                 Text: qa.Text,
//                 Status: qa.Status,
//                 User: new UserDto(qa.User.Id,
//                                   qa.User.UserName,
//                                   qa.User.FirstName,
//                                   qa.User.LastName),
//                 QuestionId: qa.QuestionId.Value.ToString(),
//                 CreatedDate: qa.CreatedDate,
//                 UpdatedDate: qa.UpdatedDate
//             ));
//         });

//         return res;
//     }
// }
