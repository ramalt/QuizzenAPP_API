using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizzerApp.Application.Common.Interfaces;
using QuizzerApp.Application.Dtos.Answer;
using QuizzerApp.Application.Dtos.User;

namespace QuizzerApp.Application.Features.Queries.Answer.ReadAnswersByUserId;

// public class ReadAnswerByUserIdQueryHandler : IRequestHandler<ReadAnswersByUserIdQuery, List<AnswerDto>>
// {
//     private readonly IRepositoryManager _manager;

//     public ReadAnswerByUserIdQueryHandler(IRepositoryManager manager)
//     {
//         _manager = manager;
//     }

//     public async Task<List<AnswerDto>> Handle(ReadAnswersByUserIdQuery request, CancellationToken cancellationToken)
//     {

//         var query = _manager.Answer.GetQueriable();

//         var userAnswers = await query.Include(ua => ua.User)
//                                      .ToListAsync(cancellationToken);

//         List<AnswerDto> res = new();

//         userAnswers.ForEach(ua =>
//         {
//             res.Add(new AnswerDto(
//                 Id: ua.Id,
//                 Text: ua.Text,
//                 Status: ua.Status,
//                 User: new UserDto(ua.User.Id,
//                                   ua.User.UserName,
//                                   ua.User.FirstName,
//                                   ua.User.LastName),
//                 QuestionId: ua.QuestionId.Value.ToString(),
//                 CreatedDate: ua.CreatedDate,
//                 UpdatedDate: ua.UpdatedDate
//             ));
//         });

//         return res;
//     }
// }
