namespace QuizzenApp.Domain.Entities.ExamAggregate;

public record Exam(string examType, string topic)
{

    public static Exam Create(string value)
    {
        var splitLocalization = value.Split(',');
        return new(splitLocalization.First(), splitLocalization.Last());
    }

    public override string ToString()
    {
        return $"{examType}-{topic}";
    }


}
