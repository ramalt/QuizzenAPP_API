namespace QuizzenApp.Domain.Entities.ExamAggregate;

public record Exam(string ExamType, string Topic)
{

    public static Exam Create(string value)
    {
        var splitLocalization = value.Split(',');
        return new(splitLocalization.First(), splitLocalization.Last());
    }

    public override string ToString()
    {
        return $"{ExamType}-{Topic}";
    }


}
