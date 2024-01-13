using QuizzenApp.Domain.Entities.AnswerAggregate.ValueObjects;

namespace QuizzenApp.Domain.Entities.AnswerAggregate;

public class AnswerImage
{
    public Guid Id { get; set; }
    public AnswerId AnswerId { get; set; }
    public Answer Answer { get; set; }
    public string ImgPath { get; set; }
    public DateTime CreatedDate { get; set; }


    public AnswerImage()
    {

    }

    public AnswerImage(Guid id, AnswerId answerId, string imgPath)
    {
        ImgPath = imgPath;
        AnswerId = answerId;
        Id = id;
        CreatedDate = DateTime.Now;
    }
}
