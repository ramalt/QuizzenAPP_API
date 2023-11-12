using System.Collections.Generic;

namespace QuizzerApp.Infrastructure.EFCore.Models;

public class ExamModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<ExamTopicModel> Topics { get; set; }
    public List<QuestionModel> Questions { get; set; }
}

public class ExamTopicModel
{
    public string Name { get; set; }
    public Guid ExamId { get; set; }
    public ExamModel Exam { get; set; }
}
