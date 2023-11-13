namespace QuizzenApp.Domain.Entities.AnswerAggregate.ValueObjects;

public class AnswerImage
{
    public AnswerImageId Id { get; private set; }
    public string Url { get; set; }

    public AnswerId AnswerId { get; set; }
    public Answer Answer { get; set; }

    public AnswerImage(AnswerImageId id, string url)
    {
        Id = id;
        Url = url;   
    }

    public AnswerImage()
    {
        
    }
}
