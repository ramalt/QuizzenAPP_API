using QuizzenApp.Domain.Entities.ExamAggregate.ValueObjects;
using QuizzenApp.Shared.Domain;

namespace QuizzenApp.Domain.Entities.ExamAggregate;

public class Exam : AggregateRoot<ExamId>
{
    public ExamId Id { get; private set; }
    public string Name { get; private set; }
    public List<ExamTopic> Topics { get; private set; }

    public Exam(Guid id, string name, List<ExamTopic> topics)
    {
        Id = id;
        Name = name;
        Topics = topics;
    }

}
