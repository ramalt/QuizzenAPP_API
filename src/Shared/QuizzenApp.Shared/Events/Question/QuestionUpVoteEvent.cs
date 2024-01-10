namespace QuizzenApp.Shared.Events.Question;

public record QuestionUpVoteEvent(Guid QuestionId, string UserId);
