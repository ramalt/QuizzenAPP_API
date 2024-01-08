namespace QuizzerApp.Application.Dtos.Question;

public record QuestionDto(Guid Id, string Title, string Description, string Status, string ownerId, Guid ExamId, Guid SubjectId, Guid TopicId, DateTime CreatedDate);
