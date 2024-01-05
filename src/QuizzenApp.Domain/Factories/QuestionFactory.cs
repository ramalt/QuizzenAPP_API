using QuizzenApp.Domain.Entities.ExamAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate;
using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;

namespace QuizzenApp.Domain.Factories;

public class QuestionFactory : IQuestionFactory
{
    public Question Create(QuestionTitle title, string examType, QuestionDescription description, string userId, List<QuestionImage> images)
    {
        Exam exam = Exam.Create(examType);
        return new Question(id: Guid.NewGuid(), title: title, description: description, exam: exam, userId: userId);
    }

}
