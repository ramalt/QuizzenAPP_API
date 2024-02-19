namespace QuizzerApp.Application.Features.Queries.Question.ReadQuestionByUserId;

// public class ReadQuestionsByUserIdQueryHandler : IRequestHandler<ReadQuestionsByUserIdQuery, List<QuestionDto>>
// {
//     private readonly IRepositoryManager _manager;

//     public ReadQuestionsByUserIdQueryHandler(IRepositoryManager manager)
//     {
//         _manager = manager;
//     }

//     public async Task<List<QuestionDto>> Handle(ReadQuestionsByUserIdQuery request, CancellationToken cancellationToken)
//     {
//         // var userQuestions = await _manager.Question.GetAllByUserIdAsync(request.UserId);
//         var query = _manager.Question.GetQueriable();

//         var userQuestions = await query.Include(q => q.User)
//                    .Include(q => q.Exam)
//                    .Include(q => q.Subject)
//                    .Include(q => q.Topic)
//                    .Where(q => q.UserId == request.UserId)
//                    .ToListAsync(cancellationToken);


//         List<QuestionDto> res = new();




//         userQuestions.ForEach(uq =>
//         {

//             res.Add(new QuestionDto(
//                 Id: uq.Id,
//                 Title: uq.Title,
//                 Description: uq.Description,
//                 Status: uq.Status.ToString(),
//                 User: new UserDto(uq.UserId,
//                                   uq.User.UserName,
//                                   uq.User.FirstName,
//                                   uq.User.LastName),
//                 Tags: new ExamDto(uq.Exam.Name, uq.Subject.Name, uq.Topic.Name),
//                 CreatedDate: uq.CreatedDate
//             ));
//         });

//         return res;
//     }
// }
