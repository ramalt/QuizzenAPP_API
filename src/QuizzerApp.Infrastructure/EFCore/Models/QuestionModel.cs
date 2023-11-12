using Microsoft.AspNetCore.Identity;

namespace QuizzerApp.Infrastructure.EFCore.Models;

public class QuestionModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public QuestionStatusModel Status {get; set;}
    public List<AnswerModel> Answers { get; set; }

    public Guid ExamId { get; set; }
    public ExamModel Exam { get; set; }

    public string UserId { get; set; }
    public UserModel User { get; set; }
}

public enum QuestionStatusModel
{
    active,
    inactive,
    solved
}
