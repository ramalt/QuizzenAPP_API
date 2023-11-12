namespace QuizzerApp.Infrastructure.EFCore.Models;

public class AnswerModel
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public List<AnswerImageModel> Images { get; set; }
    public AnswerStatusModel Status { get; set; }

    public string UserId { get; set; }
    public UserModel User { get; set; }

    public Guid QuestionId { get; set; }
    public QuestionModel Question { get; set; }
}

public enum AnswerStatusModel
{
    active,
    approved,
    deleted
}

public class AnswerImageModel
{
    public Guid Id { get; set; }
    public string Url { get; set; }
    public Guid AnswerId { get; set; }
}

