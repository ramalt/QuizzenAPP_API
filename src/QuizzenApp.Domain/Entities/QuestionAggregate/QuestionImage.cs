using QuizzenApp.Domain.Entities.QuestionAggregate.ValueObjects;

namespace QuizzenApp.Domain.Entities.QuestionAggregate;

public class QuestionImage
{
    public Guid Id { get; set; }
    public QuestionId QuestionId { get; set; }
    public Question Question { get; set; }
    public string ImgPath { get; set; }
    public DateTime CreatedDate { get; set; }


    public QuestionImage()
    {

    }

    public QuestionImage(Guid id, QuestionId questionId, string imgPath)
    {
        ImgPath = imgPath;
        QuestionId = questionId;
        Id = id;
        CreatedDate = DateTime.Now;
    }
}
