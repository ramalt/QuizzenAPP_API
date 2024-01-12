using QuizzerApp.Application.Dtos.Exam;
using QuizzerApp.Application.Dtos.User;

namespace QuizzerApp.Application.Dtos.Question;

public record QuestionDto(Guid Id,
                          string Title,
                          string Description,
                          string Status,
                          UserDto User,
                          ExamDto Tags,
                          DateTime CreatedDate);
