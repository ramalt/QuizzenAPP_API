using QuizzenApp.Domain.Entities.ExamAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;
using QuizzenApp.Domain.Entities.UserAggregate;

namespace QuizzenApp.Domain.Factories;

public class QuestionFactory : IQuestionFactory
{
    public Question Create(QuestionTitle title, string examType, QuestionDescription description, User user, List<QuestionImage> images)
    {
        Exam exam = Exam.Create(examType);
        User owner = new(user.UserName, user.ProfilePic, user.Gender);
        return new (Guid.NewGuid(), title, description, images ,exam,  owner );
    }

}
