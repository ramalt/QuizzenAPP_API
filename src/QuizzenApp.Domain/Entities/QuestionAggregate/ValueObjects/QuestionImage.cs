using System.ComponentModel.DataAnnotations;

namespace QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;

public class QuestionImage
{
  public QuestionImageId Id { get; set; }
  public string Url { get; private set; }

  public QuestionId QuestionId { get; set; }
  public Question Question { get; set; }

  public QuestionImage()
  {
    
  }

  public QuestionImage(QuestionImageId id, string url)
  {
    Id = id;
    Url = url;
  }
}
