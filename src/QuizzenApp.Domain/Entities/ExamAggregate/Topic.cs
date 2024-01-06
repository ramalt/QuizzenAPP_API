using QuizzenApp.Domain.Entities.QuestionAggregate;

namespace QuizzenApp.Domain.Entities.ExamAggregate;

public class Topic
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ExamId { get; set; }
    public Exam Exam { get; set; }
    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; }
    public ICollection<Question> Questions;

    public Topic()
    {

    }

    public Topic(Guid id, string name, Guid examId, Guid subjectId)
    {
        Id = id;
        Name = name;
        ExamId = examId;
        SubjectId = subjectId;
    }

}
