using QuizzenApp.Domain.Entities.QuestionAggregate;

namespace QuizzenApp.Domain.Entities.ExamAggregate;

public class Exam 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Subject> Subjects;
    public ICollection<Topic> Topics;
    public ICollection<Question> Questions;


    public Exam()
    {

    }

    public Exam(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    // public static Exam Create(string value)
    // {
    //     var splitLocalization = value.Split(',');
    //     return new(splitLocalization.First(), splitLocalization.Last());
    // }

    // public override string ToString()
    // {
    //     return $"{ExamType}-{Topic}";
    // }


}
