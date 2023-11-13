namespace QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;

public class QuestionImage
{
  public QuestionImageId Id { get; private set; }
  public string Url { get; private set; }

  public QuestionId QuestionId { get; private set; }
  public Question Question { get; private set; }

  public QuestionImage() { }

  public QuestionImage(QuestionImageId id, string url)
  {
    Id = id;
    Url = url;
  }
}
