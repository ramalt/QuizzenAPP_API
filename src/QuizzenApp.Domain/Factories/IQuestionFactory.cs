using QuizzenApp.Domain.Entities.QuestionAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;
using QuizzenApp.Domain.Entities.UserAggregate;

namespace QuizzenApp.Domain.Factories;

public interface IQuestionFactory
{
    Question Create(QuestionTitle title, string examType, QuestionDescription description, User user, List<QuestionImage> images);
}
