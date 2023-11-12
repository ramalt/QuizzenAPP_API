using QuizzenApp.Domain.Entities.ExamAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;
using QuizzenApp.Domain.Entities.UserAggregate;

namespace QuizzenApp.Domain.Factories;

public class QuestionFactory : IQuestionFactory
{
    public Question Create(QuestionTitle title, Exam examType, QuestionDescription description, User user)
    {
        Exam exam = new(examType.Id, examType.Name, examType.Topics);
        QuestionDescription questionDesc = new(description.Text, description.Images);
        User owner = new(user.UserName, user.ProfilePic, user.Gender);
        return new (Guid.NewGuid(), title, questionDesc, exam,  user );
    }

}
